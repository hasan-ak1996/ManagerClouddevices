using Abp.Application.Services;
using AutoMapper;
using D.input.DTO;
using output.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using update.DTO;
using System.Linq;
using Abp.Domain.Repositories;
using ManageCloudDevices.Authorization.Users;

namespace ManageCloudDevices.Device
{
    public class DeviceAppService : ApplicationService, IDeviceAppService
    {
        private readonly DeviceManager.DeviceManager deviceManager;
        private readonly IMapper objectMapper;
        private readonly UserManager _userManager;
        private readonly IRepository<ManageCloudDevices.Models.Device> deviceRepository;

        public DeviceAppService(DeviceManager.DeviceManager deviceManager, IMapper objectMapper,
             UserManager userManager,
             IRepository<ManageCloudDevices.Models.Device> deviceRepository
           )
        {
            this.deviceManager = deviceManager;
            this.objectMapper = objectMapper;
            _userManager = userManager;
            this.deviceRepository = deviceRepository;
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


        public async Task UpdateDeviceFromSystem(DeviceUpdateInputDto input)
        {
           var user =  _userManager.Users.Where(u => u.SecretKey == input.SecretKey).FirstOrDefault();
            var userId = user.Id;
            var devicesFromUser = deviceRepository.GetAll().Where(d => d.UserId == userId).ToList();
           var device = devicesFromUser.Where(d => d.PublicKey == input.PublicKey).FirstOrDefault();
            device.IP = input.IP;
            device.PrivateKey = input.PrivateKey;
            await deviceManager.UpdateDeviceFromSystem(device);



        }
    }
}
