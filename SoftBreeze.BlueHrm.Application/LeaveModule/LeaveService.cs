using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.UI;
using AutoMapper;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.LeaveModule;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation;
using SoftBreeze.BlueHrm.LeaveModule.Dto;

using System.Linq.Dynamic;
using Abp.Authorization;
using Abp.Linq.Extensions;
using SoftBreeze.BlueHrm.Authorization;
using Tony.Common.Infrastructure;

namespace SoftBreeze.BlueHrm.LeaveModule
{
    public class LeaveService : BlueHrmAppServiceBase, ILeaveService
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveEntitlmentRepository _leaveEntitlmentRepository;
        private readonly ILeavePeriodRepository _leavePeriodRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveService(ILeaveTypeRepository leaveTypeRepository,
            ILeaveEntitlmentRepository leaveEntitlmentRepository,
            ILeavePeriodRepository leavePeriodRepository,
            IEmployeeRepository employeeRepository,
            ILeaveRepository leaveRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveEntitlmentRepository = leaveEntitlmentRepository;
            _leavePeriodRepository = leavePeriodRepository;
            _employeeRepository = employeeRepository;
            _leaveRepository = leaveRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }

        #region Leavetypes
        public OutputBase SaveLeaveType(SaveLeaveTypeInput input)
        {
            if (_leaveTypeRepository.Query(q => q.Any(l => l.Name == input.LeaveType.Name && l.Id != input.LeaveType.Id)))
            {
                return new OutputBase { Message = "A type with the same name have been added", Success = false };
            }
            _leaveTypeRepository.InsertOrUpdate(Mapper.Map<LeaveType>(input.LeaveType));
            return new OutputBase { Message = "Saved successfuly", Success = true };
        }

        public LeaveTypeDto GetLeaveType(GetLEaveTypeInput input)
        {
            return Mapper.Map<LeaveTypeDto>(_leaveTypeRepository.Get(input.LeaveTypeId));
        }

        public ListResultOutput<LeaveTypeDto> GetLeaveTypes()
        {
            return new ListResultOutput<LeaveTypeDto>(Mapper.Map<List<LeaveTypeDto>>(_leaveTypeRepository.GetAllList()));
        }

        public OutputBase DeleteLeaveType(DeleteLeaveTypeInput input)
        {
            _leaveTypeRepository.Delete(input.LeaveTypeId);
            return new OutputBase { Message = "Type deleted", Success = true };
        }
        #endregion

        #region leave period
        public ListResultOutput<LeavePeriodDto> GetLeavePeriods()
        {
            return new ListResultOutput<LeavePeriodDto>(Mapper.Map<List<LeavePeriodDto>>(_leavePeriodRepository.GetAll()));
        }
        #endregion

        #region LeaveEntitlement

        public OutputBase SaveEntitlement(SaveLeaveEntitlementInput input)
        {
            var employee = _employeeRepository.FirstOrDefault(e => e.Number == input.LeaveEntitlement.EmployeeNumber);
            if (employee == null) return new OutputBase { Message = "Invalid employee number", Success = false };

            input.LeaveEntitlement.EmployeeId = employee.Id;
            if (
                _leaveEntitlmentRepository.Query(
                    q =>
                        q.Any(
                            ent =>
                                ent.EmployeeId == input.LeaveEntitlement.EmployeeId &&
                                ent.LeaveTypeId == input.LeaveEntitlement.LeaveTypeId &&
                                ent.Id != input.LeaveEntitlement.Id)))
            {
                return new OutputBase
                {
                    Message = "You have added an entitlement for this employee for the selected leave type",
                    Success = false
                };
            }
            _leaveEntitlmentRepository.InsertOrUpdate(Mapper.Map<LeaveEntitlement>(input.LeaveEntitlement));
            return new OutputBase { Message = "Saved successfully", Success = true };
        }

        public OutputBase DeleteEntitlement(DeleteLeaveEntitlementInput input)
        {
            _leaveEntitlmentRepository.Delete(input.LeaveEntitlementId);
            return new OutputBase { Message = "Deleted", Success = true };
        }

        public LeaveEntitlementDto GetLeaveEntitlement(GetLeaveEntitlementInput input)
        {
            return _leaveEntitlmentRepository.Query(q => q.Include(e => e.Employee).Select(e => new LeaveEntitlementDto
            {
                LeaveTypeId = e.LeaveTypeId,
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                NumberOfDays = e.NumberOfDays,
                PeriodId = e.PeriodId,
                EmployeeNumber = e.Employee.Number
            }).FirstOrDefault());
        }

        public ListResultOutput<LeaveEntitlementDto> GetLeaveEntitlements(GetLeaveEntitlementsInput input)
        {
            var entitlements = new List<LeaveEntitlement>();
            if (input.EmployeeId != null)
                entitlements = _leaveEntitlmentRepository.GetAllList(e => e.EmployeeId == input.EmployeeId.Value);

            else entitlements = _leaveEntitlmentRepository.GetAllList();
            return new ListResultOutput<LeaveEntitlementDto>(Mapper.Map<List<LeaveEntitlementDto>>(entitlements));
        }

        public ListResultOutput<LeaveEntitlementDo> GetLeaveEntitlementDos(GetLeaveEntitlementsInput input)
        {
            var employee = _employeeRepository.FirstOrDefault(e => e.Number == input.EmployeeNumber);
            if (employee == null) return new ListResultOutput<LeaveEntitlementDo>();
            var entitlements = _leaveEntitlmentRepository.GetEntitlements(l => l.EmployeeId == employee.Id);
            if (input.LeaveTypeId == null)
            {
                if (input.PeriodId != null)
                    return new ListResultOutput<LeaveEntitlementDo>(
                        entitlements.Where(e => e.PeriodId == input.PeriodId).ToList());
            }
            else
            {
                if (input.PeriodId != null)
                    return
                        new ListResultOutput<LeaveEntitlementDo>(
                            entitlements.Where(e => e.PeriodId == input.PeriodId && e.LeaveTypeId == input.LeaveTypeId)
                                .ToList());
                return
                        new ListResultOutput<LeaveEntitlementDo>(
                            entitlements.Where(e => e.LeaveTypeId == input.LeaveTypeId)
                                .ToList());
            }
            return new ListResultOutput<LeaveEntitlementDo>(entitlements.ToList());
        }
        #endregion

        #region leaveRequest
        [AbpAuthorize(AppPermissions.Pages_Leave_LeaveRequest_MakeRequest)]
        public OutputBase MakeLeaveRequest(MakeLeaveRequestInput input)
        {
            if (input.LeaveRequest.EmployeeId == 0) input.LeaveRequest.EmployeeId = GetCurrentUser().Id;
            var period =
                _leavePeriodRepository.FirstOrDefault(
                    p => input.LeaveRequest.StartDate >= p.StatDate && input.LeaveRequest.EndDate <= p.EndDate);
            if (period == null)
                return new OutputBase { Message = "There is no leave period within the selected date", Success = false };
            var leaveType = _leaveTypeRepository.Get(input.LeaveRequest.LeaveTypeId);

            var entitlment =
                _leaveEntitlmentRepository.FirstOrDefault(ent => ent.LeaveTypeId == input.LeaveRequest.LeaveTypeId &&
                                                                 ent.EmployeeId == input.LeaveRequest.EmployeeId && ent.PeriodId == period.Id);
            if (entitlment == null)
            {
                return new OutputBase
                {
                    Message = string.Format("You are not entitled to any {0} for {1}", leaveType.Name, period.Range),
                    Success = false
                };
            }

            //check for pending leave request
            if (_leaveRequestRepository.Query(q => q.Any(lr => lr.EmployeeId == input.LeaveRequest.EmployeeId &&
                                                               lr.Status == LeaveRequestStatus.Pending)))
            {
                return new OutputBase
                {
                    Message =
                        "You still have a pending leave request. " +
                        "You can either delete the request or wait untill it is processed to continue",
                    Success = false
                };
            }

            var duration = Math.Abs(new TimeStamp(input.LeaveRequest.StartDate, true).
                DaysDifference(new TimeStamp(input.LeaveRequest.EndDate)));
            var daysTaken =
                _leaveRepository.Query(
                    q =>
                        q.Any(
                            l =>
                                l.LeaveEntitlment.EmployeeId == input.LeaveRequest.EmployeeId &&
                                l.LeaveEntitlment.PeriodId == period.Id &&
                                l.LeaveEntitlment.LeaveTypeId == input.LeaveRequest.LeaveTypeId))
                    ? _leaveRepository.GetAll().Where(l =>
                        l.LeaveEntitlment.EmployeeId == input.LeaveRequest.EmployeeId &&
                        l.LeaveEntitlment.PeriodId == period.Id &&
                        l.LeaveEntitlment.LeaveTypeId == input.LeaveRequest.LeaveTypeId).Sum(l => l.NumberOfDays)
                    : 0;
            var daysLeft = entitlment.NumberOfDays - daysTaken;
            if (duration > daysLeft)
                return new OutputBase
                {
                    Message =
                        string.Format("You cannot take {3} days again. You have already taken {0} days from your {1}. You are now left with {2} days",
                            daysTaken, leaveType.Name, daysLeft, duration),
                    Success = false
                };
            _leaveRequestRepository.Insert(new LeaveRequest
            {
                EmployeeId = input.LeaveRequest.EmployeeId,
                EndDate = input.LeaveRequest.EndDate,
                Status = LeaveRequestStatus.Pending,
                StartDate = input.LeaveRequest.StartDate,
                LeaveTypeId = input.LeaveRequest.LeaveTypeId,
                Note = input.LeaveRequest.Note
            });
            return new OutputBase { Message = "Request saved", Success = true };
        }

        public OutputBase DeleteLeaveRequest(DeleteLeaveRequestInput input)
        {
            var request = _leaveRequestRepository.Get(input.LeaveRequestId);
            if (request.EmployeeId != GetCurrentUserId() &&
                !IsGranted(AppPermissions.Pages_Leave_LeaveRequest_DeleteAny))
            {
                return new OutputBase { Message = "You cannot delete a request that is not yours", Success = false };
            }
            _leaveRequestRepository.Delete(request);
            return new OutputBase { Message = "Request deleted", Success = true };
        }

        public OutputBase ApproveLeaveRequest(ApproveLeaveRequestInput input)
        {
            var request = _leaveRequestRepository.FirstOrDefault(r => r.Id == input.LeaveRequestId);
            if (request == null) return new OutputBase {Message = "Invalid Request Id", Success = false};
            var employee = _employeeRepository.Get(request.EmployeeId);
            request.Status = LeaveRequestStatus.Approved;
            return AssignLeave(new AssignLeaveInput
            {
                LeaveTypeId = request.LeaveTypeId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                EmployeeNumber = employee.Number
            });
        }

        public OutputBase RejectLeaveRequest(RejectLeaveRequestInput input)
        {
            var request = _leaveRequestRepository.FirstOrDefault(r => r.Id == input.LeaveRequestId);
            if (request == null) return new OutputBase {Message = "Request not found", Success = false};
            request.Status = LeaveRequestStatus.Rejected;
            _leaveRequestRepository.Update(request);
            return new OutputBase {Message = "Leave rejected", Success = true};
        }

        public LeaveRequestDto GetLeaveRequestDto(GetLeaveRequestInput input)
        {
            return
                Mapper.Map<LeaveRequestDto>(_leaveRequestRepository.FirstOrDefault(lr => lr.Id == input.LeaveRequestId));
        }

        public int GetPendingLeaveRequestCount()
        {
            return _leaveRequestRepository.Count(r => r.Status == LeaveRequestStatus.Pending);
        }
        public async Task<PagedResultOutput<LeaveRequestDo>> GetLeaveRequests(GetLeaveRequestsInput input)
        {
            try
            {
                //if the request can view all leave request: get employeeId if employeenumber is set
                long employeeId = 0;
                if (IsGranted(AppPermissions.Pages_Leave_LeaveRequest_ViewAll))
                {
                    if (!string.IsNullOrEmpty(input.EmployeeNumber))
                    {
                        var employee = _employeeRepository.GetEmployeeByNumber(input.EmployeeNumber);
                        if (employee == null)
                        {
                            return null;
                        }
                        employeeId = employee.Id;
                    }
                }
                else employeeId = GetCurrentUserId();

                IEnumerable<LeaveRequestDo> queryable;

                if (employeeId == 0)
                {
                    if (input.StartDate == null)
                        queryable = input.Status == null
                            ? _leaveRequestRepository.GetRequestDos()
                            : _leaveRequestRepository.GetRequestDos(l => l.Status == input.Status.Value);
                    else
                    {
                        queryable = input.Status == null
                            ? _leaveRequestRepository.GetRequestDos(
                                l => l.StartDate >= input.StartDate.Value && l.EndDate <= input.EndDate.Value)
                            : _leaveRequestRepository.GetRequestDos(l => l.Status == input.Status.Value &&
                                                                         l.StartDate >= input.StartDate.Value &&
                                                                         l.EndDate <= input.EndDate.Value);
                    }
                }
                else
                {
                    if (input.StartDate == null)
                        queryable = input.Status == null
                            ? _leaveRequestRepository.GetRequestDos(l => l.EmployeeId == employeeId)
                            : _leaveRequestRepository.GetRequestDos(l => l.EmployeeId == employeeId && l.Status == input.Status.Value);
                    else
                    {
                        queryable = input.Status == null
                            ? _leaveRequestRepository.GetRequestDos(
                                l => l.EmployeeId == employeeId && l.StartDate >= input.StartDate.Value && l.EndDate <= input.EndDate.Value)
                            : _leaveRequestRepository.GetRequestDos(l => l.EmployeeId == employeeId && l.Status == input.Status.Value &&
                                                                         l.StartDate >= input.StartDate.Value &&
                                                                         l.EndDate <= input.EndDate.Value);
                    }
                }

                var query = queryable.AsQueryable();

                var requestCount = await query.CountAsync();
                var requestList = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();


                return new PagedResultOutput<LeaveRequestDo>(
                    requestCount,
                    requestList
                    );
            }
            catch (Exception exception)
            {
                return new PagedResultOutput<LeaveRequestDo>();
            }

        }
        #endregion

        #region leave

        public OutputBase AssignLeave(AssignLeaveInput input)
        {
            var employee = _employeeRepository.FirstOrDefault(e => e.Number == input.EmployeeNumber);
            if (employee == null) return new OutputBase { Message = "Invalid Employee number", Success = false };
            var leavType = _leaveTypeRepository.FirstOrDefault(lt => lt.Id == input.LeaveTypeId);
            if (leavType == null) return new OutputBase { Message = "Invalid leave type ID", Success = false };
            var period =
                _leavePeriodRepository.FirstOrDefault(p => input.StartDate >= p.StatDate && input.EndDate <= p.EndDate);
            if (period == null)
                return new OutputBase
                {
                    Message = "The selected date range does not fall into any leave period",
                    Success = false
                };

            var entitement =
                _leaveEntitlmentRepository.FirstOrDefault(
                    ent => ent.EmployeeId == employee.Id &&
                        ent.LeaveTypeId == input.LeaveTypeId && ent.PeriodId == period.Id);
            if (entitement == null)
            {
                return new OutputBase
                {
                    Message =
                        string.Format("{0} {1} {2} has no {3} for to selected period", employee.FirstName,
                            employee.LastName,
                            employee.MiddleName, leavType.Name),
                    Success = false
                };
            }
            var leavesTaken =
                _leaveRepository.GetAllList(
                    l => l.LeaveEntitlment.EmployeeId == employee.Id && l.LeaveEntitlment.LeaveTypeId ==
                         leavType.Id && l.LeaveEntitlment.PeriodId == period.Id);

            var daysTaken = leavesTaken.Any() ? leavesTaken.Sum(l => l.NumberOfDays) : 0;
            var daysLeft = entitement.NumberOfDays - daysTaken;
            var numberOfDays = Math.Abs(new TimeStamp(input.EndDate).DaysDifference(new TimeStamp(input.StartDate)));

            if (numberOfDays > daysLeft)
            {
                return new OutputBase
                {
                    Message = string.Format("{0} has alredy taken {1} days from his {2}. The leave balance is now {3}",
                        employee.Fullname, daysTaken, leavType.Name, daysLeft),
                    Success = false
                };
            }
            _leaveRepository.Insert(new Leave
            {
                Comment = input.Comment,
                EndDate = input.EndDate,
                StartDate = input.StartDate,
                EntitlementId = entitement.Id,
                NumberOfDays = numberOfDays,
                Status = LeaveStatus.Approved
            });

            return new OutputBase { Message = "Leave scheduled", Success = true };
        }
        public async Task<PagedResultOutput<LeaveDo>> GetLeaves(GetLeavesInput input)
        {
            try
            {
                IEnumerable<LeaveDo> query;

                if (input.EmployeeNumber != string.Empty)
                {
                    if (input.StartDate == null)
                    {
                        query =
                            _leaveRepository.GetLeaves(l => l.LeaveEntitlment.Employee.Number == input.EmployeeNumber);
                    }
                    else
                    {
                        query =
                            _leaveRepository.GetLeaves(l => l.LeaveEntitlment.Employee.Number == input.EmployeeNumber &&
                                                            l.StartDate >= input.StartDate && l.EndDate <= input.EndDate);
                    }
                }

                else if (input.StartDate == null)
                {
                    query = input.SubunitId == null ? _leaveRepository.GetLeaves() :
                        _leaveRepository.GetLeaves(l => l.LeaveEntitlment.Employee.JobInformation.UnitId == input.SubunitId);
                }
                else
                {
                    query = input.SubunitId == null ?
                        _leaveRepository.GetLeaves(l => l.StartDate >= input.StartDate && l.EndDate <= input.EndDate) :
                        _leaveRepository.GetLeaves(l => l.LeaveEntitlment.Employee.JobInformation.UnitId == input.SubunitId &&
                        l.StartDate >= input.StartDate && l.EndDate <= input.EndDate);
                }
                //filter by status
                query = input.Status == LeaveStatus.All ? query : query.Where(e => e.Status == input.Status);

                var queriable = query.AsQueryable();
                var leaveCount = await queriable.CountAsync();
                var leaveList = await queriable
                       .OrderBy(input.Sorting)
                       .PageBy(input)
                       .ToListAsync();

                return new PagedResultOutput<LeaveDo>(
                       leaveCount,
                       leaveList
                       );
            }
            catch (Exception exception)
            {
                //ignore
                return new PagedResultOutput<LeaveDo>();
            }

        }

        public LeaveDo GetLeaveDo(GetLeaveDoInput input)
        {
            return _leaveRepository.GetLeaves(l => l.Id == input.LeaveId).FirstOrDefault();
        }

        public OutputBase DeleteLeave(DeleteLeaveInput input)
        {
            _leaveRepository.Delete(input.LeaveId);
            return new OutputBase { Message = "Leave deleted", Success = true };
        }

        #endregion
    }
}
