using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IJobInformationRepository : IRepository<JobInformation, long> { }


    public class JobInformationRepository : BlueHrmRepositoryBase<JobInformation, long>, IJobInformationRepository
    {
        public JobInformationRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
