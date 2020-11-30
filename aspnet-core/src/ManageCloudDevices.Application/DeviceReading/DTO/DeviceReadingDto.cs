using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageCloudDevices.DeviceReadingDTO
{
    [AutoMap(typeof(ManageCloudDevices.Models.DeviceReading.DeviceReading))]
    public class DeviceReadingDto : EntityDto
    {
        public string ReadingName { get; set; }
        public string ValueString { get; set; }
        public bool ValueDigital { get; set; }
        public float ValueAnalog { get; set; }
        public enum ValEnum
        {
            Digital = 0,
            Analog = 1,
            Serial = 2
        }
        public ValEnum ValueType { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
