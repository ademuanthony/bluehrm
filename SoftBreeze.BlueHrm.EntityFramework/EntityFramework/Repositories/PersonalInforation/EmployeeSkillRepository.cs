using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation
{

    public interface IEmployeeSkillRepository : IRepository<EmployeeSkill> { }


    public class EmployeeSkillRepository : BlueHrmRepositoryBase<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
