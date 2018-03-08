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
    public interface ILeavePeriodRepository : IRepository<LeavePeriod> { }
    public class LeavePeriodRepository:BlueHrmRepositoryBase<LeavePeriod>, ILeavePeriodRepository
    {
        public LeavePeriodRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {
            
        }
    }
}
