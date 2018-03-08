using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{
    public interface IEmployeeMembershipRepository : IRepository<EmployeeMembership> { }


    public class EmployeeMembershipRepository : BlueHrmRepositoryBase<EmployeeMembership>, IEmployeeMembershipRepository
    {
        public EmployeeMembershipRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
