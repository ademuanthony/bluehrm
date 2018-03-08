using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface ILicenseTypeRepository : IRepository<LicenseType> { }


    public class LicenseTypeRepository : BlueHrmRepositoryBase<LicenseType>, ILicenseTypeRepository
    {
        public LicenseTypeRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
