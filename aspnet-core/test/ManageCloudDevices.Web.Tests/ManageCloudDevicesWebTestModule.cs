using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageCloudDevices.EntityFrameworkCore;
using ManageCloudDevices.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ManageCloudDevices.Web.Tests
{
    [DependsOn(
        typeof(ManageCloudDevicesWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ManageCloudDevicesWebTestModule : AbpModule
    {
        public ManageCloudDevicesWebTestModule(ManageCloudDevicesEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManageCloudDevicesWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ManageCloudDevicesWebMvcModule).Assembly);
        }
    }
}