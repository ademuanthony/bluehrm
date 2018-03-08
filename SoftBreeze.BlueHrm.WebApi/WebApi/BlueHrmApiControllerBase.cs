using Abp.WebApi.Controllers;

namespace SoftBreeze.BlueHrm.WebApi
{
    public abstract class BlueHrmApiControllerBase : AbpApiController
    {
        protected BlueHrmApiControllerBase()
        {
            LocalizationSourceName = BlueHrmConsts.LocalizationSourceName;
        }
    }
}