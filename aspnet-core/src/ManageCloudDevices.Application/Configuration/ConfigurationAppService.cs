using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ManageCloudDevices.Configuration.Dto;

namespace ManageCloudDevices.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ManageCloudDevicesAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
