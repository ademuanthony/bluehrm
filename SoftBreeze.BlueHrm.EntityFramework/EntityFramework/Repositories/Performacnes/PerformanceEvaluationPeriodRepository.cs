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
    public interface IPerformanceEvaluationPeriodRepository:IRepository<PerformanceEvaluationPeriod>
    {
    }

    public class PerformanceEvaluationPeriodRepository : BlueHrmRepositoryBase<PerformanceEvaluationPeriod>,
        IPerformanceEvaluationPeriodRepository
    {
        public PerformanceEvaluationPeriodRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {
            
        }
    }
}
