using Abp.Domain.Services;
using ManageCloudDevices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDeviceManager
{
    public interface IDeviceManager : IDomainService
    {
        Task CreateDevice(Device entity);
        Task<Device> GetDeviceByName(string name);
        Task<Device> GetDeviceById(int id);
        Task UpdateDeviceFromSystem(Device entity);
        Task<List<Device>> GetAllDevicesForUser(int userid);


    }
}
