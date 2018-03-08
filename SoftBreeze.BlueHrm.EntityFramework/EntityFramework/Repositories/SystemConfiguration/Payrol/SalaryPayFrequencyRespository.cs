using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.SystemConfiguration.Payrol;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.SystemConfiguration.Payrol
{

    public interface ISalaryPayFrequencyRespository : IRepository<SalaryPayFrequency> { }


    public class SalaryPayFrequencyRespository : BlueHrmRepositoryBase<SalaryPayFrequency>, ISalaryPayFrequencyRespository
    {
        public SalaryPayFrequencyRespository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
