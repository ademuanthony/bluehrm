using System.Reflection;
using Abp.Dependency;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Abp.Zero.Ldap;
using SoftBreeze.BlueHrm.Authorization.Roles;
using SoftBreeze.BlueHrm.Configuration;
using SoftBreeze.BlueHrm.Features;
using SoftBreeze.BlueHrm.Providers;

namespace SoftBreeze.BlueHrm
{
    /// <summary>
    /// Core (domain) module of the application.
    /// </summary>
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpZeroLdapModule))]
    public class BlueHrmCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove localization sources
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    "BlueHrm",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "SoftBreeze.BlueHrm.Localization.BlueHrm"
                        )
                    )
                );

            //Adding feature providers
            Configuration.Features.Providers.Add<AppFeatureProvider>();

            //Adding setting providers
            Configuration.Settings.Providers.Add<AppSettingProvider>();

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = false;

            //Enable LDAP authentication (It can be enabled only if MultiTenancy is disabled!)
            //Configuration.Modules.ZeroLdap().Enable(typeof(AppLdapAuthenticationSource));

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

#if DEBUG
            //Disabling email sending in debug mode
            IocManager.Register<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
#endif
        }

        public override void Initialize()
        {
            Clock.Provider = new GmtPlus1ClockProvider();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
