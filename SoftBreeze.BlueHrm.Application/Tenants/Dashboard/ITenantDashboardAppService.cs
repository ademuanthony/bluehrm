using Abp.Application.Services;
using SoftBreeze.BlueHrm.Tenants.Dashboard.Dto;

namespace SoftBreeze.BlueHrm.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
