using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.JobConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.JobConfiguration
{
   
    public interface IJobTerminationReasonRepository : IRepository<JobTerminationReason> { }


    public class JobTerminationReasonRepository : BlueHrmRepositoryBase<JobTerminationReason>, IJobTerminationReasonRepository
    {
        public JobTerminationReasonRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
