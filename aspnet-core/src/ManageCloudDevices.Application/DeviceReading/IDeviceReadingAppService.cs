using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ManageCloudDevices.DeviceReading.DTO;
using ManageCloudDevices.DeviceReadingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCloudDevices.DeviceReading
{
    public interface IDeviceReadingAppService : IApplicationService
    {
        Task CreateReading(DeviceReadingInputDto.DeviceReadingInputDto input);
        Task<PagedResultDto<DeviceReadingDto>> GetAllReadingForDevice(PagedReadingResultRequestDto input);
       
        Task UpdateReadingFromDevice(ReadingUpdateDto input);
        Task<List<DeviceReadingDto>> GetLastReadingForDevice(int id);
        Task<List<DeviceReadingDto>> GetAllReadingsByName(ReadingsByNameInputDto.ReadingsByNameInputDto input);

    }
}
