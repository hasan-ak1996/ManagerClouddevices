using Abp.AutoMapper;
using ManageCloudDevices.Models.DeviceReading;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceReadingInputDto
{
    [AutoMapTo(typeof(DeviceReading))]
    public class DeviceReadingInputDto
    {
        public int DeviceId { get; set; }
        public string ReadingName { get; set; }
        public string ValueString { get; set; }
        public bool ValueDigital { get; set; }
        public float ValueAnalog { get; set; }
        public enum my { 
            Digital =0,
            Analog =1,
            Serial =2
        }
        public my ValueType { get; set; }
    }
}
