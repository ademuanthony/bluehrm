using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.Organization;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.Organisation
{
    public interface ILocationRepository : IRepository<Location> { }


    public class LocationRepository : BlueHrmRepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
