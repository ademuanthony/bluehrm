using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.JobConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.JobConfiguration
{
    public interface IJobRepository : IRepository<Job> { }


    public class JobRepository : BlueHrmRepositoryBase<Job>, IJobRepository
    {
        public JobRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
