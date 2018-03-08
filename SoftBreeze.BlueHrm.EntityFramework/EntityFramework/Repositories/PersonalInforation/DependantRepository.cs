using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{
    public interface IDependantRepository : IRepository<Dependant> { }


    public class DependantRepository : BlueHrmRepositoryBase<Dependant>, IDependantRepository
    {
        public DependantRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
