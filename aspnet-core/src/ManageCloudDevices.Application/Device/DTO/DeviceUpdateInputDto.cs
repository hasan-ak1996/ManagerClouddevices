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
        public Guid SecretKey { get; set; }
        public Guid PublicKey { get; set; }
        public int IP { get; set; }
        public string PrivateKey { get; set; }
    }
}
