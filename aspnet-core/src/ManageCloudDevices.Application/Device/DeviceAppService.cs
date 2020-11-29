using Abp.Application.Services;
using AutoMapper;
using D.input.DTO;
using output.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using update.DTO;

namespace ManageCloudDevices.Device
{
    public class DeviceAppService : ApplicationService, IDeviceAppService
    {
        private readonly DeviceManager.DeviceManager deviceManager;
        private readonly IMapper objectMapper;

        public DeviceAppService(DeviceManager.DeviceManager deviceManager, IMapper objectMapper)
        {
            this.deviceManager = deviceManager;
            this.objectMapper = objectMapper;
        }
        public async Task CreateDevice(DeviceInputDto input)
        {
            
            ManageCloudDevices.Models.Device output = objectMapper.Map<DeviceInputDto, ManageCloudDevices.Models.Device>(input);
            output.PublicKey = Guid.NewGuid();
            output.UserId = input.UserId;

            await deviceManager.CreateDevice(output);

        }

        public async Task<DeviceDto> GetDeviceByName(string name)
        {
            var device = await deviceManager.GetDeviceByName(name);
            DeviceDto output = objectMapper.Map<ManageCloudDevices.Models.Device, DeviceDto>(device);
            return output;
        }

        public async Task<DeviceDto> GetDeviceById(int id)
        {
            var device = await deviceManager.GetDeviceById(id);
            DeviceDto output = objectMapper.Map<ManageCloudDevices.Models.Device, DeviceDto>(device);
            return output;
        }

        public Task UpdateDevice(DeviceUpdateInputDto input)
        {
            throw new NotImplementedException();
        }
    }
}
