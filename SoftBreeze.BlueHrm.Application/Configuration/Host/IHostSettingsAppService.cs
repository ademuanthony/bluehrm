using System.Threading.Tasks;
using Abp.Application.Services;
using SoftBreeze.BlueHrm.Configuration.Host.Dto;

namespace SoftBreeze.BlueHrm.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);
    }
}
