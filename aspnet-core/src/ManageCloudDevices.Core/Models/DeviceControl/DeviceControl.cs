using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageCloudDevices.Models.DeviceControl1
{
    public class DeviceControl : FullAuditedEntity<int>
    {
        public int DeviceId { get; set; }
        public string PinNumber { get; set; }
        public string ValueString { get; set; }
        public bool ValueDigital { get; set; }
        public float ValueAnalog { get; set; }
        public enum VlaueEnum { 
            Digital = 0,
            Analog = 1,
            Serial = 2
        }
        public VlaueEnum ValueType { get; set; }
        public bool IsAccessed { get; set; }
        public DateTime AccessedOn { get; set; }

    }
}
