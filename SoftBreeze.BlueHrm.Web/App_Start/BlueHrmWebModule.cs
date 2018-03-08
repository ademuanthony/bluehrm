using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.IO;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Microsoft.Owin.Security;
using SoftBreeze.BlueHrm.Web.Areas.Admin.Startup;
using SoftBreeze.BlueHrm.Web.Bundling;
using SoftBreeze.BlueHrm.Web.Navigation;
using SoftBreeze.BlueHrm.Web.Routing;
using SoftBreeze.BlueHrm.WebApi;

namespace SoftBreeze.BlueHrm.Web
{
    /// <summary>
    /// Web module of the application.
    /// This is the most top and entrance module that dependens on others.
    /// </summary>
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(BlueHrmDataModule),
        typeof(BlueHrmApplicationModule),
        typeof(BlueHrmWebApiModule))]
    public class BlueHrmWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Use database as language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
            Configuration.Navigation.Providers.Add<AdminNavigationProvider>();
        }

        public override void Initialize()
        {
            //Dependency Injection
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
                Component
                    .For<IAuthenticationManager>()
                    .UsingFactoryMethod(() => HttpContext.Current.GetOwinContext().Authentication)
                    .LifestyleTransient()
                );

            //Areas
            AreaRegistration.RegisterAllAreas();

            //Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Bundling
            BundleTable.Bundles.IgnoreList.Clear();
            CommonBundleConfig.RegisterBundles(BundleTable.Bundles);
            FrontEndBundleConfig.RegisterBundles(BundleTable.Bundles);
            MpaBundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void PostInitialize()
        {
            var tempDownloadFolder = HttpContext.Current.Server.MapPath("~/Temp/Downloads");
            IocManager.Resolve<AppFolders>().TempFileDownloadFolder = tempDownloadFolder;

            try
            {
                DirectoryHelper.CreateIfNotExists(tempDownloadFolder);
            }
            catch
            {
                //ignored
            }
        }
    }
}
