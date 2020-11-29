using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageCloudDevices.Configuration;
using ManageCloudDevices.EntityFrameworkCore;
using ManageCloudDevices.Migrator.DependencyInjection;

namespace ManageCloudDevices.Migrator
{
    [DependsOn(typeof(ManageCloudDevicesEntityFrameworkModule))]
    public class ManageCloudDevicesMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ManageCloudDevicesMigratorModule(ManageCloudDevicesEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ManageCloudDevicesMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ManageCloudDevicesConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManageCloudDevicesMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
