using System.Threading.Tasks;
using Abp.Application.Services;
using ManageCloudDevices.Authorization.Accounts.Dto;

namespace ManageCloudDevices.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
