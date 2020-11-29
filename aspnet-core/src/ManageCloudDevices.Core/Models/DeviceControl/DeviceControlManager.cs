using Abp.Domain.Repositories;
using Abp.Domain.Services;
using DeviceControlManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManageCloudDevices.Models.DeviceControl
{
    public class DeviceControlManager : DomainService, IDeviceControleManager
    {
        private readonly IRepository<DeviceControl1.DeviceControl> deviceControlRepository;

        public DeviceControlManager(IRepository<DeviceControl1.DeviceControl> deviceControlRepository)
        {
            this.deviceControlRepository = deviceControlRepository;
        }
        public async Task CreateDeviceControl(DeviceControl1.DeviceControl entity)
        {
            await deviceControlRepository.InsertAsync(entity);
        }
    }
}
