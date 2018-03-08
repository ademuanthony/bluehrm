using Abp.Modules;
using Abp.Zero.Configuration;
using SoftBreeze.BlueHrm;

namespace SoftBreeze.Tests
{
    [DependsOn(
        typeof(BlueHrmApplicationModule),
        typeof(BlueHrmDataModule))]
    public class BlueHrmTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Use database as language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
        }
    }
}
