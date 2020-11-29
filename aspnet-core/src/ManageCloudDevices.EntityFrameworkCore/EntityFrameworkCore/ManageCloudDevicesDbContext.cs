using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ManageCloudDevices.Authorization.Roles;
using ManageCloudDevices.Authorization.Users;
using ManageCloudDevices.MultiTenancy;
using ManageCloudDevices.Models;
using ManageCloudDevices.Models.DeviceControl1;
using ManageCloudDevices.Models.DeviceReading;

namespace ManageCloudDevices.EntityFrameworkCore
{
    public class ManageCloudDevicesDbContext : AbpZeroDbContext<Tenant, Role, User, ManageCloudDevicesDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Device> Device { get; set; }
        public DbSet<DeviceControl> DeviceControl { get; set; }
        public DbSet<DeviceReading> DeviceReading { get; set; }

        public ManageCloudDevicesDbContext(DbContextOptions<ManageCloudDevicesDbContext> options)
            : base(options)
        {
        }
    }
}
