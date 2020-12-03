using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace ManageCloudDevices.DeviceReading.DTO
{
    public class PagedReadingResultRequestDto : PagedResultRequestDto
    {
        public int DeviceId { get; set; }
        public override int MaxResultCount { get => base.MaxResultCount; set => base.MaxResultCount = value; }
        public override int SkipCount { get => base.SkipCount; set => base.SkipCount = value; }
    }
}
