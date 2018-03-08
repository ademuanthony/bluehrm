using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using SoftBreeze.BlueHrm.Authorization;

namespace SoftBreeze.BlueHrm
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(typeof(BlueHrmCoreModule), typeof(AbpAutoMapperModule))]
    public class BlueHrmApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Custom DTO auto-mappings
            CustomDtoMapper.CreateMappings();
        }
    }
}
