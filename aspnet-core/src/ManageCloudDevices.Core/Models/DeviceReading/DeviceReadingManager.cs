using Abp.Domain.Repositories;
using Abp.Domain.Services;
using InterfaceDeviceReadingManager;
using ManageCloudDevices.Models;
using ManageCloudDevices.Models.DeviceReading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReadingManagerClass
{
    public class DeviceReadingManager : DomainService, IDeviceReadingManager
    {
        private readonly IRepository<DeviceReading> _deviceReadingRepository;
        private readonly IRepository<Device> deviceRepository;

        public DeviceReadingManager(IRepository<DeviceReading> deviceReadingRepository,
            IRepository<Device> deviceRepository)
        {
            _deviceReadingRepository = deviceReadingRepository;
            this.deviceRepository = deviceRepository;
        }
        public async Task CreateReading(DeviceReading entity)
        {
            await _deviceReadingRepository.InsertAsync(entity);
        }

        public async Task<List<DeviceReading>> GetAllReadingForDevice(int id)
        {
            return await _deviceReadingRepository.GetAllListAsync(r => r.DeviceId == id);
        }

        public async Task UpdateReadingFromDevice(DeviceReading entity)
        {
            await _deviceReadingRepository.UpdateAsync(entity);
        }
    }
}
