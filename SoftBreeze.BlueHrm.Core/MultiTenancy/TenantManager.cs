using Abp.MultiTenancy;
using SoftBreeze.BlueHrm.Authorization.Roles;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.Editions;

namespace SoftBreeze.BlueHrm.MultiTenancy
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}
