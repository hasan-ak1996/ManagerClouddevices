using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceControlService
{
    public interface IDeviceControlAppService : IApplicationService
    {
        Task CreateControl(CreateControlInputDto.CreateControlInputDto input);
    }
}
