using Abp.AutoMapper;
using ManageCloudDevices.Models.DeviceReading;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingsByNameInputDto
{
    [AutoMapTo(typeof(DeviceReading))]
    public class ReadingsByNameInputDto
    {
        public int DeviceId { get; set; }
        public string ReadingName { get; set; }
    }
}
