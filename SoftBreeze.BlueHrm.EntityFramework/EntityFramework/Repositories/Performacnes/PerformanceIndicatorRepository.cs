using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.Performance;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.Performacnes
{
    public interface IPerformanceIndicatorRepository: IRepository<PerformanceIndicator>
    {
    }

    public class PerformanceIndicatorRepository : BlueHrmRepositoryBase<PerformanceIndicator>, IPerformanceIndicatorRepository
    {
        public PerformanceIndicatorRepository(IDbContextProvider<BlueHrmDbContext> provider) :base(provider)
        {
            
        }
    }
}
