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
        Task<DeviceDto> GetDeviceForView(int userid);
        Task<DeviceDto> GetDeviceById(int id);
        Task UpdateDeviceFromSystem(DeviceUpdateInputDto input);
        Task<List<DeviceDto>> GetAllDevicesForUser(int userid);
    }
}
