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
    public interface ILeaveRepository : IRepository<Leave>
    {
        IEnumerable<LeaveDo> GetLeaves(Expression<Func<Leave, bool>> predicate = null);
    }
    public class LeaveRepository:BlueHrmRepositoryBase<Leave>, ILeaveRepository
    {
        public LeaveRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {
            
        }

        public IEnumerable<LeaveDo> GetLeaves(Expression<Func<Leave, bool>> predicate = null)
        {
            return (predicate != null ? Table.Where(predicate) : Table).Select(l => new LeaveDo
            {
                Id = l.Id,
                Comment = l.Comment,
                EndDate = l.EndDate,
                Status = l.Status,
                LeaveType = l.LeaveEntitlment.LeaveType.Name,
                LeaveTypeId = l.LeaveEntitlment.LeaveTypeId,
                NumberOfDays = l.NumberOfDays,
                EmployeeNumber = l.LeaveEntitlment.Employee.Number,
                EmployeeName =
                    l.LeaveEntitlment.Employee.FirstName + " " + 
                    l.LeaveEntitlment.Employee.LastName + " " +
                    l.LeaveEntitlment.Employee.MiddleName,
                StartDate = l.StartDate
            });
        } 
    }
}
