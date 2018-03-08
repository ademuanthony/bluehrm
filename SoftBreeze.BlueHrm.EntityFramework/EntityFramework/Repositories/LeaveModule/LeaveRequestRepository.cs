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
    public interface ILeaveRequestRepository : IRepository<LeaveRequest>
    {
        IEnumerable<LeaveRequestDo> GetRequestDos(Expression<Func<LeaveRequest, bool>> predicate = null);
    }
    public class LeaveRequestRepository:BlueHrmRepositoryBase<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(IDbContextProvider<BlueHrmDbContext> provider):base(provider) { }

        public IEnumerable<LeaveRequestDo> GetRequestDos(Expression<Func<LeaveRequest, bool>> predicate = null)
        {
            return (predicate != null ? Table.Where(predicate) : Table).Select(r => new LeaveRequestDo
            {
                Employee = r.Employee.FirstName + " " + r.Employee.LastName + " " + r.Employee.MiddleName,
                LeaveType = r.LeaveType.Name,
                Id = r.Id,
                EndDate = r.EndDate,
                StartDate = r.StartDate,
                Note = r.Note,
                Status = r.Status,
                CreationTime = r.CreationTime
            });
        }
    }
}
