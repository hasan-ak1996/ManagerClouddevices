using Abp.AutoMapper;
using ManageCloudDevices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.input.DTO
{
    [AutoMapTo(typeof(Device))]
    public class DeviceInputDto
    {
        public string  DeviceName { get; set; }
        public long UserId { get; set; }
    }
}
