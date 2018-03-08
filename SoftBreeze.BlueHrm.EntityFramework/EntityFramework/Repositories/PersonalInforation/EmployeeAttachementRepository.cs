using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.JobConfiguration;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IEmployeeAttachementRepository : IRepository<EmployeeAttachement> { }


    public class EmployeeAttachementRepository : BlueHrmRepositoryBase<EmployeeAttachement>, IEmployeeAttachementRepository
    {
        public EmployeeAttachementRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
