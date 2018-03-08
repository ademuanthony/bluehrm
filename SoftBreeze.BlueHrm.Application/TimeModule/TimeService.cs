using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Timing;
using AutoMapper;
using SoftBreeze.BlueHrm.Dto;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.TimeModule;
using SoftBreeze.BlueHrm.TimeModule.Dto;
using Tony.Common.Infrastructure;

using System.Linq.Dynamic;
using Abp.Linq.Extensions;
using System;

namespace SoftBreeze.BlueHrm.TimeModule
{
    public class TimeService : BlueHrmAppServiceBase, ITimeService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TimeService(IAttendanceRepository attendanceRepository,
            IEmployeeRepository employeeRepository)
        {
            _attendanceRepository = attendanceRepository;
            _employeeRepository = employeeRepository;
        }



        public OutputBase SaveAttendance(SaveAttendanceInput input)
        {
            var date = new TimeStamp(Clock.Now, true).Date;
            var employee = _employeeRepository.FirstOrDefault(emp => emp.Number == input.EmployeeNumber);
            if (employee == null) return new OutputBase { Message = "Invalid employee number", Success = false };

            var checkIn = new TimeStamp(date, true).AddHours(input.HourIn).AddMinutes(input.MuniteIn).Date;
            DateTime? checkOut = null;
            if (input.HourOut != null && input.MuniteOut != null)
                checkOut = new TimeStamp(date, true).AddHours(input.HourOut.Value).AddMinutes(input.MuniteOut.Value).Date;

            if (_attendanceRepository.Query(
                    q => q.Any(at => at.Date == input.Date && at.Id != input.Id)))
            {
                return new OutputBase
                {
                    Message = string.Format("An attendance entry have already been made for {0} for {1}", 
                        employee.Fullname, date.ToShortDateString())
                };
            }
            var attendance = new AttendanceDto
            {
                ClockIn = checkIn,
                ClockOut = checkOut,
                Date = date,
                EmployeeId = employee.Id,
                Id = input.Id ?? 0
            };

            _attendanceRepository.InsertOrUpdate(Mapper.Map<Attendance>(attendance));
            return new OutputBase { Message = "Attendance saved", Success = true };
        }

        public async Task<OutputBase> Clockin(ClockInInput input)
        {
            var user = await GetCurrentUserAsync();
            var employee = _employeeRepository.FirstOrDefault(emp => emp.Id == user.Id);
            var date = new TimeStamp(Clock.Now, true).Date;

            if (_attendanceRepository.Query(q => q.Any(at => at.Date == date && at.EmployeeId == employee.Id)))
            {
                return new OutputBase
                {
                    Message =
                        string.Format("Welcome back {0}! You have already been clocked in for today", employee.Fullname),
                    Success = false
                };
            }

            _attendanceRepository.Insert(new Attendance { ClockIn = Clock.Now, Date = date, EmployeeId = employee.Id });
            return new OutputBase
            {
                Message = string.Format("Welcome {0}! You have been clocked in", employee.Fullname),
                Success = true
            };
        }

        public async Task<OutputBase> ClockOut(ClockoutInput input)
        {
            var user = await GetCurrentUserAsync();
            var employee = _employeeRepository.FirstOrDefault(emp => emp.Id == user.Id);
            var date = new TimeStamp(Clock.Now, true).Date;

            var attendance = _attendanceRepository.FirstOrDefault(at => at.Date == date && at.EmployeeId == employee.Id);
            if (attendance == null)
            {
                return new OutputBase { Message = "You have not been clocked in for today", Success = false };
            }
            attendance.ClockOut = Clock.Now;
            _attendanceRepository.Update(attendance);

            return new OutputBase
            {
                Message = string.Format("Good bye {0}! You have been clocked out", employee.Fullname),
                Success = true
            };
        }

        public OutputBase DeleteAttendance(DeleteAttanceInput input)
        {
            _attendanceRepository.Delete(input.AttendanceId);
            return new OutputBase { Message = "Attendance delete", Success = true };
        }

        public List<AttendanceDto> GetAttendanceDtos(GetAttendanceDtosInput input)
        {
            var query = _attendanceRepository.GetAll();
            if (input.EmployeeNumber != string.Empty)
            {
                var employee = _employeeRepository.FirstOrDefault(emp => emp.Number == input.EmployeeNumber);
                if (employee == null) return new List<AttendanceDto>();
                query = query.Where(at => at.EmployeeId == employee.Id);
                if (input.StartDate != null)
                {
                    if (input.EndDate == null) query = query.Where(at => at.Date == input.StartDate.Value);
                }
                else
                {
                    query = query.Where(at => at.ClockIn >= input.StartDate && at.ClockOut <= input.EndDate);
                }
            }
            else
            {
                if (input.StartDate != null)
                {
                    if (input.EndDate == null) query = query.Where(at => at.Date == input.StartDate.Value);
                }
                else
                {
                    query = query.Where(at => at.ClockIn >= input.StartDate && at.ClockOut <= input.EndDate);
                }
            }
            return Mapper.Map<List<AttendanceDto>>(query.ToList());
        }

        public ListResultOutput<AttendanceDo> GetAttendanceReports(GetAttendanceReportsInput input)
        {
            return new ListResultOutput<AttendanceDo>(_attendanceRepository.GetAttendanceReport(input.Date).ToList());
        } 

        public AttendanceDto GetAttendanceDto(GetAttendanceDtoInput input)
        {
            return Mapper.Map<AttendanceDto>(_attendanceRepository.FirstOrDefault(at => at.Id == input.AttendanceId));
        }

        public async Task<PagedResultOutput<AttendanceDo>> GetAttendances(GetAttendanceDtosInput input)
        {

            try
            {
                var query = _attendanceRepository.GetAttendanceDos();
                if (input.EmployeeNumber != string.Empty)
                {
                    var employee = _employeeRepository.FirstOrDefault(emp => emp.Number == input.EmployeeNumber);
                    if (employee == null) return new PagedResultOutput<AttendanceDo>();

                    query = query.Where(at => at.EmployeeId == employee.Id);
                    if (input.StartDate != null)
                    {
                        if (input.EndDate == null) query = query.Where(at => at.Date == input.StartDate.Value);
                        else
                        {
                            query = query.Where(at => at.ClockIn >= input.StartDate && at.ClockOut <= input.EndDate);
                        }
                    }

                }
                else
                {
                    if (input.StartDate != null)
                    {
                        if (input.EndDate == null) query = query.Where(at => at.Date == input.StartDate.Value);
                        else query = query.Where(at => at.ClockIn >= input.StartDate && at.ClockOut <= input.EndDate);
                    }
                }

                var atQuerible = query.AsQueryable();
                var itemCount = await atQuerible.CountAsync();
                var attendanceList = await atQuerible
                        .OrderBy(input.Sorting)
                        .PageBy(input)
                        .ToListAsync();
                return new PagedResultOutput<AttendanceDo>(itemCount, attendanceList);

            }
            catch (Exception ex)
            {
                return new PagedResultOutput<AttendanceDo>();
            }

        }

    }
}
