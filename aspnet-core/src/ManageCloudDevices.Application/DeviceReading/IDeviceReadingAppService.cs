using Abp.Application.Services;
using ManageCloudDevices.DeviceReading.DTO;
using ManageCloudDevices.DeviceReadingDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManageCloudDevices.DeviceReading
{
    public interface IDeviceReadingAppService : IApplicationService
    {
        Task CreateReading(DeviceReadingInputDto.DeviceReadingInputDto input);
        Task<List<DeviceReadingDto>> GetAllReadingForDevice(int id);
        Task UpdateReadingFromDevice(ReadingUpdateDto input);
    }
}
