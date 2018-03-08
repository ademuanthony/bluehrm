using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.JobConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.JobConfiguration
{
    public interface IEmploymentStatusRepository : IRepository<EmploymentStatus> { }


    public class EmploymentStatusRepository:BlueHrmRepositoryBase<EmploymentStatus>, IEmploymentStatusRepository
    {
        public EmploymentStatusRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
