using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ManageCloudDevices.Configuration;
using ManageCloudDevices.Web;

namespace ManageCloudDevices.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ManageCloudDevicesDbContextFactory : IDesignTimeDbContextFactory<ManageCloudDevicesDbContext>
    {
        public ManageCloudDevicesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ManageCloudDevicesDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ManageCloudDevicesDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ManageCloudDevicesConsts.ConnectionStringName));

            return new ManageCloudDevicesDbContext(builder.Options);
        }
    }
}
