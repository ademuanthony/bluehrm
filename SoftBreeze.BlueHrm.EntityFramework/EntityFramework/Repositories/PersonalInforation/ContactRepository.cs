using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IContactRepository : IRepository<Contact, long> { }


    public class ContactRepository : BlueHrmRepositoryBase<Contact,long>, IContactRepository
    {
        public ContactRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
