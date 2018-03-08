using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface ICountyRepository : IRepository<Country> { }


    public class CountyRepository : BlueHrmRepositoryBase<Country>, ICountyRepository
    {
        public CountyRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
