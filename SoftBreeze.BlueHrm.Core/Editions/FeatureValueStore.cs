using Abp.Application.Features;
using SoftBreeze.BlueHrm.Authorization.Roles;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.MultiTenancy;

namespace SoftBreeze.BlueHrm.Editions
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager) 
            : base(tenantManager)
        {
        }
    }
}
