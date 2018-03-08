using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface ILanguageRepository : IRepository<BlueHrmLanguage> { }


    public class LanguageRepository : BlueHrmRepositoryBase<BlueHrmLanguage>, ILanguageRepository
    {
        public LanguageRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
