using Abp.Application.Services;
using AutoMapper;
using DeviceReadingManagerClass;
using ManageCloudDevices.Authorization.Users;
using ManageCloudDevices.DeviceReading.DTO;
using ManageCloudDevices.DeviceReadingDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManageCloudDevices.DeviceReading
{
    public class DeviceReadingAppService : ApplicationService, IDeviceReadingAppService
    {
        private readonly IMapper _objectMapper;
        private readonly DeviceReadingManager _deviceReadingManager;
        private readonly UserManager _userManager;
        private readonly IRepository<Models.Device> _deviceRepository;
        private readonly IRepository<Models.DeviceReading.DeviceReading> _deviceReadingRepository;

        public DeviceReadingAppService(
            IMapper objectMapper,
            DeviceReadingManager deviceReadingManager,
            UserManager userManager,
            IRepository<ManageCloudDevices.Models.Device> deviceRepository,
            IRepository<ManageCloudDevices.Models.DeviceReading.DeviceReading> deviceReadingRepository
            )
        {
            _objectMapper = objectMapper;
            _deviceReadingManager = deviceReadingManager;
            _userManager = userManager;
            _deviceRepository = deviceRepository;
            _deviceReadingRepository = deviceReadingRepository;
        }
        public async Task CreateReading(DeviceReadingInputDto.DeviceReadingInputDto input)
        {
            ManageCloudDevices.Models.DeviceReading.DeviceReading output = _objectMapper.Map<DeviceReadingInputDto.DeviceReadingInputDto, ManageCloudDevices.Models.DeviceReading.DeviceReading>(input);
            await _deviceReadingManager.CreateReading(output);
        }
        public async Task<List<DeviceReadingDto>> GetAllReadingForDevice(int id)
        {
            var getAll = await _deviceReadingManager.GetAllReadingForDevice(id);
            
            List<DeviceReadingDto> output = _objectMapper.Map<List<ManageCloudDevices.Models.DeviceReading.DeviceReading>, List<DeviceReadingDto>>(getAll);
            return output;
        }

        public async Task<List<DeviceReadingDto>> GetAllReadingsByName(ReadingsByNameInputDto.ReadingsByNameInputDto input)
        {
            var getAll = await _deviceReadingManager.GetAllReadingForDevice(input.DeviceId);
            var readings = getAll.Where(r => r.ReadingName == input.ReadingName).ToList();
            List<DeviceReadingDto> output = _objectMapper.Map<List<ManageCloudDevices.Models.DeviceReading.DeviceReading>, List<DeviceReadingDto>>(readings);
            return output;
        }

        public async Task<List<DeviceReadingDto>> GetLastReadingForDevice(int id)
        {
            var AllReading =await _deviceReadingRepository.GetAll().Where(r => r.DeviceId == id).ToListAsync();
            var LastReadings = AllReading.GroupBy(r => r.ReadingName).SelectMany(y => y.Where(z => z.CreationTime == y.Max(i => i.CreationTime))).ToList();
            List<DeviceReadingDto> output = _objectMapper.Map<List<ManageCloudDevices.Models.DeviceReading.DeviceReading>, List<DeviceReadingDto>>(LastReadings);
            return output;
        }

        public async Task UpdateReadingFromDevice(ReadingUpdateDto input)
        {
            var user = await _userManager.Users.Where(u => u.SecretKey == input.SecretKey).FirstOrDefaultAsync();
            var userId = user.Id;
            var devicesFromUser = await _deviceRepository.GetAll().Where(d => d.UserId == userId).ToListAsync();
            var device = devicesFromUser.Where(d => d.PublicKey == input.PublicKey).FirstOrDefault();
            var deviceId = device.Id;
            var deviceReadingsFromDevice = await _deviceReadingRepository.GetAll().Where(c => c.DeviceId == deviceId).ToListAsync();
            var deviceReading = deviceReadingsFromDevice.Where(r => r.ReadingName == input.ReadingName).FirstOrDefault();
            deviceReading.ValueType = (Models.DeviceReading.DeviceReading.VlaueEnum)input.ValueType;
            deviceReading.ValueAnalog = input.ValueAnalog;
            deviceReading.ValueDigital = input.ValueDigital;
            deviceReading.ValueString = input.ValueString;
            await _deviceReadingManager.UpdateReadingFromDevice(deviceReading);

        }
    }
}
