using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IEmployeeEmergencyContactRepository : IRepository<EmployeeEmergencyContact> { }


    public class EmployeeEmergencyContactRepository : BlueHrmRepositoryBase<EmployeeEmergencyContact>, IEmployeeEmergencyContactRepository
    {
        public EmployeeEmergencyContactRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
