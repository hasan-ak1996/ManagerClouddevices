using Abp.Domain.Services;
using ManageCloudDevices.Models.DeviceReading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDeviceReadingManager
{
    public interface IDeviceReadingManager : IDomainService
    {
        Task CreateReading(DeviceReading entity);
        Task<List<DeviceReading>> GetAllReadingForDevice(int id);
        Task UpdateReadingFromDevice(DeviceReading entity);
    }
}
