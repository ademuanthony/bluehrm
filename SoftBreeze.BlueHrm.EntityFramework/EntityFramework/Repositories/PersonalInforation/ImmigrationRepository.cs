using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{
    public interface IImmigrationRepository : IRepository<Immigration> { }


    public class ImmigrationRepository : BlueHrmRepositoryBase<Immigration>, IImmigrationRepository
    {
        public ImmigrationRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
