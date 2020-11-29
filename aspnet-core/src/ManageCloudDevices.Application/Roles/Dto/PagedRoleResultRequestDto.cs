using Abp.Application.Services.Dto;

namespace ManageCloudDevices.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

