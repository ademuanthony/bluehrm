using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.JobConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.JobConfiguration
{
   public interface IJobCategoryRepository : IRepository<JobCategory> { }


    public class JobCategoryRepository : BlueHrmRepositoryBase<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
