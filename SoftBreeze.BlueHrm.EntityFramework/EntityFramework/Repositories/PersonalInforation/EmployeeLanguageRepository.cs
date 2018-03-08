using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IEmployeeLanguageRepository : IRepository<EmployeeLanguage> { }


    public class EmployeeLanguageRepository : BlueHrmRepositoryBase<EmployeeLanguage>, IEmployeeLanguageRepository
    {
        public EmployeeLanguageRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
