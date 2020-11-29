using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageCloudDevices.Configuration;

namespace ManageCloudDevices.Web.Host.Startup
{
    [DependsOn(
       typeof(ManageCloudDevicesWebCoreModule))]
    public class ManageCloudDevicesWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ManageCloudDevicesWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManageCloudDevicesWebHostModule).GetAssembly());
        }
    }
}
