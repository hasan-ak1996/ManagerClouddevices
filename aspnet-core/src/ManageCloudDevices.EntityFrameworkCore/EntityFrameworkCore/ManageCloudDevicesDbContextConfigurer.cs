using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ManageCloudDevices.EntityFrameworkCore
{
    public static class ManageCloudDevicesDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ManageCloudDevicesDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ManageCloudDevicesDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
