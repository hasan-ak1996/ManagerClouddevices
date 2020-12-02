using Abp.Application.Services;
using AutoMapper;
using DeviceControlService;
using ManageCloudDevices.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManageCloudDevices.DeviceControl
{
    public class DeviceControlAppService : ApplicationService, IDeviceControlAppService
    {
        private readonly Models.DeviceControl.DeviceControlManager deviceControlManager;
        private readonly IMapper objectMapper;
        private readonly UserManager _userManager;
        private readonly IRepository<Models.DeviceControl1.DeviceControl> _deviceControlRepository;
        private readonly IRepository<Models.Device> _deviceRepository;

        public DeviceControlAppService(ManageCloudDevices.Models.DeviceControl.DeviceControlManager deviceControlManager
            ,IMapper objectMapper,
            UserManager userManager,
            IRepository<Models.DeviceControl1.DeviceControl> deviceControlRepository,
            IRepository<ManageCloudDevices.Models.Device> deviceRepository
            )
        {
            this.deviceControlManager = deviceControlManager;
            this.objectMapper = objectMapper;
            _userManager = userManager;
            _deviceControlRepository = deviceControlRepository;
            _deviceRepository = deviceRepository;
        }
        public async Task CreateControl(CreateControlInputDto.CreateControlInputDto input)
        {
            ManageCloudDevices.Models.DeviceControl1.DeviceControl output = objectMapper.Map<CreateControlInputDto.CreateControlInputDto, ManageCloudDevices.Models.DeviceControl1.DeviceControl>(input);

            await deviceControlManager.CreateDeviceControl(output);
        }

        public async Task<GetValueControlOutputDto.GetValueControlOutputDto> GetValueControl(ReadingValueInputDto.ReadingValueInputDto input)
        {
            var user = await  _userManager.Users.Where(u => u.SecretKey == input.SecretKey).FirstOrDefaultAsync();
            var userId = user.Id;
            var devicesFromUser = await _deviceRepository.GetAll().Where(d => d.UserId == userId).ToListAsync();
            var device = devicesFromUser.Where(d => d.PublicKey == input.PublicKey).FirstOrDefault();
            var deviceId = device.Id;
            var deviceControlsFromDevice = await _deviceControlRepository.GetAll().Where(c => c.DeviceId == deviceId).ToListAsync();
            var deviceControl = deviceControlsFromDevice.Where(c => c.PinNumber == input.PinNumber).FirstOrDefault();

            GetValueControlOutputDto.GetValueControlOutputDto output =  objectMapper.Map<ManageCloudDevices.Models.DeviceControl1.DeviceControl, GetValueControlOutputDto.GetValueControlOutputDto>(deviceControl);
            var valueT = deviceControl.ValueType;
            if (deviceControl.ValueType == 0)
            {
                output.Value = deviceControl.ValueDigital.ToString();
            }else if (valueT.ToString() == "1")
            {
                output.Value = deviceControl.ValueAnalog.ToString();
            }
            else
            {
                output.Value = deviceControl.ValueString;
            }
            return  output;
        }
    }
}
