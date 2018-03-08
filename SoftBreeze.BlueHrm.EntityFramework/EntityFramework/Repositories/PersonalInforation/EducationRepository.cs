using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{
   
    public interface IEducationRepository : IRepository<Education> { }


    public class EducationRepository : BlueHrmRepositoryBase<Education>, IEducationRepository
    {
        public EducationRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
