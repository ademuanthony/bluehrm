using Abp.Domain.Services;

namespace SoftBreeze.BlueHrm
{
    public abstract class BlueHrmDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected BlueHrmDomainServiceBase()
        {
            LocalizationSourceName = BlueHrmConsts.LocalizationSourceName;
        }
    }
}
