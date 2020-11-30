using Abp.AutoMapper;
using ManageCloudDevices.Models.DeviceControl1;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetValueControlOutputDto
{
    [AutoMap(typeof(DeviceControl))]
    public class GetValueControlOutputDto
    {
        public string Value { get; set; }
    }
}
