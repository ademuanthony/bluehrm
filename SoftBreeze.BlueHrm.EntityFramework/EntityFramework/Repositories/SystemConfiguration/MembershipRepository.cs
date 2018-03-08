using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface IMembershipRepository : IRepository<Membership> { }


    public class MembershipRepository : BlueHrmRepositoryBase<Membership>, IMembershipRepository
    {
        public MembershipRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
