using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ManageCloudDevices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager
{
    public class DeviceManager : DomainService, IDeviceManager.IDeviceManager {
        private readonly IRepository<Device> _deviceRepository;

        public DeviceManager(IRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task CreateDevice(Device entity)
        {
            await _deviceRepository.InsertAsync(entity);
        }

        public async Task<Device> GetDeviceById(int id)
        {
            return await _deviceRepository.GetAsync(id);
        }

        public async Task<Device> GetDeviceByName(string name)
        {
            return await _deviceRepository.FirstOrDefaultAsync(d => d.DeviceName == name);
        }
    }
}
