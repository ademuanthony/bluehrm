using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface ICurrencyRepository : IRepository<Currency> { }


    public class CurrencyRepository : BlueHrmRepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
