using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IJobExperienceRepository : IRepository<JobExperience> { }


    public class JobExperienceRepository : BlueHrmRepositoryBase<JobExperience>, IJobExperienceRepository
    {
        public JobExperienceRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
