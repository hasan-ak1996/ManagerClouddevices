using Abp.AutoMapper;
using ManageCloudDevices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace update.DTO
{
    [AutoMapTo(typeof(Device))]
    public class DeviceUpdateInputDto
    {
        public string DeviceName { get; set; }
        public Enum Status { get; set; }
    }
}
