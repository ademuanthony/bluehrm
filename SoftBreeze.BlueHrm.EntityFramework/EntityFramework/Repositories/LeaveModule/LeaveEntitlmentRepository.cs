using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.LeaveModule;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.LeaveModule
{
    public interface ILeaveEntitlmentRepository : IRepository<LeaveEntitlement>
    {
        IEnumerable<LeaveEntitlementDo> GetEntitlements(Expression<Func<LeaveEntitlement, bool>> predicate = null);
    }

    public class LeaveEntitlmentRepository:BlueHrmRepositoryBase<LeaveEntitlement>, ILeaveEntitlmentRepository
    {
        public LeaveEntitlmentRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }

        public IEnumerable<LeaveEntitlementDo> GetEntitlements(Expression<Func<LeaveEntitlement, bool>> predicate = null)
        {
            return (predicate == null ? Table : Table.Where(predicate)).Select(e => new LeaveEntitlementDo
            {
                Id = e.Id,
                LeaveTypeId = e.LeaveTypeId,
                LeaveType = e.LeaveType.Name,
                PeriodId = e.PeriodId,
                StartDate = e.LeavePeriod.StatDate,
                EndDate = e.LeavePeriod.EndDate,
                EmployeeNumber = e.Employee.Number,
                NumberOfDays = e.NumberOfDays
            });
        }
    }
}
