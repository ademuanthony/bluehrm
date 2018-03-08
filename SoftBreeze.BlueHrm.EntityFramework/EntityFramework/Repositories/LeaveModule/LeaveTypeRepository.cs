using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.LeaveModule;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.LeaveModule
{
    public interface ILeaveTypeRepository : IRepository<LeaveType> { }
    public class LeaveTypeRepository:BlueHrmRepositoryBase<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
