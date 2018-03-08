using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using SoftBreeze.BlueHrm.Organization;

namespace SoftBreeze.BlueHrm.EntityFramework.Repositories.Organisation
{
    public interface IGeneralInformationRepository : IRepository<GeneralInformation> { }
    public class GeneralInformationRepository:BlueHrmRepositoryBase<GeneralInformation>, IGeneralInformationRepository
    {
        public GeneralInformationRepository(IDbContextProvider<BlueHrmDbContext> provider) : base(provider)
        {
            
        }
    }
}
