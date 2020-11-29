using Abp.Application.Services;
using AutoMapper;
using DeviceControlService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManageCloudDevices.DeviceControl
{
    public class DeviceControlAppService : ApplicationService, IDeviceControlAppService
    {
        private readonly Models.DeviceControl.DeviceControlManager deviceControlManager;
        private readonly IMapper objectMapper;

        public DeviceControlAppService(ManageCloudDevices.Models.DeviceControl.DeviceControlManager deviceControlManager,IMapper objectMapper)
        {
            this.deviceControlManager = deviceControlManager;
            this.objectMapper = objectMapper;
        }
        public async Task CreateControl(CreateControlInputDto.CreateControlInputDto input)
        {
            ManageCloudDevices.Models.DeviceControl1.DeviceControl output = objectMapper.Map<CreateControlInputDto.CreateControlInputDto, ManageCloudDevices.Models.DeviceControl1.DeviceControl>(input);

            await deviceControlManager.CreateDeviceControl(output);
        }
    }
}
