using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.JobConfiguration;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.JobConfiguration
{

    public interface IPayGradeRepository : IRepository<PayGrade> { }


    public class PayGradeRepository : BlueHrmRepositoryBase<PayGrade>, IPayGradeRepository
    {
        public PayGradeRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider) { }
    }
}
