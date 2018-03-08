using Abp.Domain.Repositories;
using Abp.EntityFramework;
using BlueHrm.SystemConfiguration;
using SoftBreeze.BlueHrm.SystemConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration
{
    public interface ISkillRepository : IRepository<Skill> { }


    public class SkillRepository : BlueHrmRepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
