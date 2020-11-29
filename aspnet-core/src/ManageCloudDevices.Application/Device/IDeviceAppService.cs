using Abp.Application.Services;
using D.input.DTO;
using output.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using update.DTO;

namespace ManageCloudDevices.Device
{
    public interface IDeviceAppService : IApplicationService
    {
        Task CreateDevice(DeviceInputDto input);
        Task<DeviceDto> GetDeviceByName( string name );
        Task<DeviceDto> GetDeviceById(int id);
        Task UpdateDevice(DeviceUpdateInputDto input);
    }
}
