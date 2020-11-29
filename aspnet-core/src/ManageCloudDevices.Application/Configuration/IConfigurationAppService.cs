using System.Threading.Tasks;
using ManageCloudDevices.Configuration.Dto;

namespace ManageCloudDevices.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
