using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;
using SoftBreeze.BlueHrm.Authorization.Users;
using SoftBreeze.BlueHrm.EntityFramework.Repositories.PersonalInforation;
using SoftBreeze.BlueHrm.MultiTenancy;
using SoftBreeze.BlueHrm.PersonalInformation;

namespace SoftBreeze.BlueHrm
{
    /// <summary>
    /// All application services in this application is derived from this class.
    /// We can add common application service methods here.
    /// </summary>
    public abstract class BlueHrmAppServiceBase : ApplicationService
    {

        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected BlueHrmAppServiceBase()
        {
            LocalizationSourceName = BlueHrmConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual User GetCurrentUser()
        {
            var user = UserManager.FindById(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected long GetCurrentUserId()
        {
            return AbpSession.GetUserId();
        }


        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual Tenant GetCurrentTenant()
        {
            return TenantManager.GetById(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}