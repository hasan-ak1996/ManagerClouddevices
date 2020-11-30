using Abp.AutoMapper;
using ManageCloudDevices.Models.DeviceControl1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingValueInputDto
{
    [AutoMapTo(typeof(DeviceControl))]
    public class ReadingValueInputDto
    {
        public Guid SecretKey { get; set; }
        public Guid PublicKey { get; set; }
        public string PinNumber { get; set; }
    }
}
