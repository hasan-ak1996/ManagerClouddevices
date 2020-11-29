using Abp.AutoMapper;
using ManageCloudDevices.Models.DeviceControl1;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateControlInputDto
{
    [AutoMapTo(typeof(DeviceControl))]
    public class CreateControlInputDto
    {
        public int DeviceId { get; set; }
        public string PinNumber { get; set; }
        public string ValueString { get; set; }
        public bool ValueDigital { get; set; }
        public float ValueAnalog { get; set; }
        public enum VlaueEnum
        {
            Digital = 0,
            Analog = 1,
            Serial = 2
        }
        public VlaueEnum ValueType { get; set; }
        public bool IsAccessed { get; set; }

    }
}
