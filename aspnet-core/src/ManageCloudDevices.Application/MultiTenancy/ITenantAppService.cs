using Abp.Application.Services;
using ManageCloudDevices.MultiTenancy.Dto;

namespace ManageCloudDevices.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

