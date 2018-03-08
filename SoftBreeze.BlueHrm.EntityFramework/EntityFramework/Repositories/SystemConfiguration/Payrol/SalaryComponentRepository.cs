using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.SystemConfiguration.Payrol;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration.Payrol
{
    public interface ISalaryComponentRepository : IRepository<SalaryComponent> { }


    public class SalaryComponentRepository : BlueHrmRepositoryBase<SalaryComponent>, ISalaryComponentRepository
    {
        public SalaryComponentRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
