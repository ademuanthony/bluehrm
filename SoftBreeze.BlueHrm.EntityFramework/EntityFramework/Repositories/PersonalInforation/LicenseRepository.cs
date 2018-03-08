using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface ILicenseRepository : IRepository<License> { }


    public class LicenseRepository : BlueHrmRepositoryBase<License>, ILicenseRepository
    {
        public LicenseRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
