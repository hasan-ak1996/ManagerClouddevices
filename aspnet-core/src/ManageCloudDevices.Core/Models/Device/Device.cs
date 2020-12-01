using Abp.Domain.Entities.Auditing;
using ManageCloudDevices.Models.DeviceControl1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageCloudDevices.Models
{
    public class Device : FullAuditedEntity<int>
    {
        public long UserId { get; set; }
        public Guid PublicKey {get;set;}
        public string PrivateKey { get; set; }
        public string DeviceName { get; set; }
        public int IP { get; set; }
        public enum myenum { 
            Active =0 ,
            Disabled =1 
        }
        public myenum Status { get; set; }
        public virtual List<ManageCloudDevices.Models.DeviceControl1.DeviceControl> DeviceControls { get; set; }
        public virtual List<ManageCloudDevices.Models.DeviceReading.DeviceReading> DeviceReadings { get; set; }

    }
}
