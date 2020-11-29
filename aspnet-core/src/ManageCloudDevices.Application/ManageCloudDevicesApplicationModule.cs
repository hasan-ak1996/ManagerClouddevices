using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageCloudDevices.Authorization;

namespace ManageCloudDevices
{
    [DependsOn(
        typeof(ManageCloudDevicesCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ManageCloudDevicesApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ManageCloudDevicesAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ManageCloudDevicesApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
