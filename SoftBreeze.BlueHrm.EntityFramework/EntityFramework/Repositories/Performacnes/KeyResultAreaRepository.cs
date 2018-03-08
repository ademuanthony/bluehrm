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
    public interface IKeyResultAreaRepository:IRepository<KeyResultArea>
    {
        IEnumerable<KeyResultAreaDo> GetResultAreaDos(int performanceId);
    }

    public class KeyResultAreaRepository : BlueHrmRepositoryBase<KeyResultArea>, IKeyResultAreaRepository
    {
        public KeyResultAreaRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {
            
        }

        public IEnumerable<KeyResultAreaDo> GetResultAreaDos(int performanceId)
        {
            return Table.Where(k => k.PerformanceId == performanceId).Select(k => new KeyResultAreaDo
            {
                Id = k.Id,
                AttributeId = k.AttributeId,
                PerformanceId = k.PerformanceId,
                ActualAcheivement = k.ActualAcheivement,
                Comment = k.Comment,
                Kpi = k.Attribute.Name,
                Rating = k.Rating
            });
        }
    }
}
