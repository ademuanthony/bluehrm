﻿using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.MultiTenancy;

namespace SoftBreeze.BlueHrm.Authorization.Roles
{
    /// <summary>
    /// Role manager.
    /// Used to implement domain logic for roles.
    /// </summary>
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(RoleStore store, IPermissionManager permissionManager, IRoleManagementConfig roleManagementConfig, ICacheManager cacheManager)
            : base(store, permissionManager, roleManagementConfig, cacheManager)
        {
            
        }
    }
}