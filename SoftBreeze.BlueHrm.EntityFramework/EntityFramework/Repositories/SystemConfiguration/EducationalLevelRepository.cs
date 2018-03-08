using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface IEducationalLevelRepository : IRepository<EducationalLevel> { }


    public class EducationalLevelRepository : BlueHrmRepositoryBase<EducationalLevel>, IEducationalLevelRepository
    {
        public EducationalLevelRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
