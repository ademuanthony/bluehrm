using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.Performance;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.Performacnes
{
    public interface IConcludingRemarkRepository:IRepository<ConcludingRemark>
    {
    }

    public class ConcludingRemarkRepository : BlueHrmRepositoryBase<ConcludingRemark>, IConcludingRemarkRepository
    {
        public ConcludingRemarkRepository(IDbContextProvider<BlueHrmDbContext> provider):base(provider) { }

    }
}
