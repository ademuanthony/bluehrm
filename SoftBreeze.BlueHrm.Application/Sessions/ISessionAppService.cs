using System.Threading.Tasks;
using Abp.Application.Services;
using SoftBreeze.BlueHrm.Sessions.Dto;

namespace SoftBreeze.BlueHrm.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
