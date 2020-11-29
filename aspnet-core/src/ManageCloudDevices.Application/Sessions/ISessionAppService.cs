using System.Threading.Tasks;
using Abp.Application.Services;
using ManageCloudDevices.Sessions.Dto;

namespace ManageCloudDevices.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
