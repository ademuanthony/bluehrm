using Abp.Configuration;
using Abp.Dependency;
using Abp.Web.Mvc.Views;

namespace SoftBreeze.BlueHrm.Web.Views
{
    public abstract class BlueHrmWebViewPageBase : BlueHrmWebViewPageBase<dynamic>
    {

    }

    public abstract class BlueHrmWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public ISettingManager SettingManager { get; set; }

        protected BlueHrmWebViewPageBase()
        {
            LocalizationSourceName = BlueHrmConsts.LocalizationSourceName;
            SettingManager = IocManager.Instance.Resolve<ISettingManager>();
        }
    }
}