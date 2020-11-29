using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using ManageCloudDevices.EntityFrameworkCore.Seed;

namespace ManageCloudDevices.EntityFrameworkCore
{
    [DependsOn(
        typeof(ManageCloudDevicesCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class ManageCloudDevicesEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ManageCloudDevicesDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ManageCloudDevicesDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        ManageCloudDevicesDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManageCloudDevicesEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
