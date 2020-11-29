using Abp.Domain.Services;
using ManageCloudDevices.Models.DeviceControl1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceControlManager
{
    public interface IDeviceControleManager : IDomainService
    {
        Task CreateDeviceControl(DeviceControl entity);
    }
}
