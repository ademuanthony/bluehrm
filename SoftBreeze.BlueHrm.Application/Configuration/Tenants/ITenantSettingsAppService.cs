using System.Threading.Tasks;
using Abp.Application.Services;
using SoftBreeze.BlueHrm.Configuration.Tenants.Dto;

namespace SoftBreeze.BlueHrm.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);
    }
}
