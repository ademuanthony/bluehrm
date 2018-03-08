using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.Organization;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface IUnitRepository : IRepository<Unit> { }

    public class UnitRepository:BlueHrmRepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {
            
        }
    }
}
