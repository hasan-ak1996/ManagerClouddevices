using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageCloudDevices.DeviceReading.DTO
{
    [AutoMapTo(typeof(ManageCloudDevices.Models.DeviceReading.DeviceReading))]
    public class ReadingUpdateDto
    {
        public Guid SecretKey { get; set; }
        public Guid PublicKey { get; set; }
        public string ReadingName { get; set; }
        public string ValueString { get; set; }
        public bool ValueDigital { get; set; }
        public float ValueAnalog { get; set; }
        public enum TypeEnum
        {
            Digital,
            Analog,
            Serial 
        }
        public TypeEnum ValueType { get; set; }
    }
}
