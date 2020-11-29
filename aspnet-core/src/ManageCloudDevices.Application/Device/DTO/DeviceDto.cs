using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ManageCloudDevices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace output.DTO
{
    [AutoMap(typeof(Device))]
    public class DeviceDto : EntityDto
    {
        public Guid PublicKey { get; set; }
        public string DeviceName { get; set; }
        public int IP { get; set; }
        public enum myenum
        {
            Active = 1,
            Disabled = 0
        }
        public myenum Status { get; set; }
    }
}
