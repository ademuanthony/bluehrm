using Abp.Authorization;
using SoftBreeze.BlueHrm.Authorization.Roles;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.MultiTenancy;

namespace SoftBreeze.BlueHrm.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
