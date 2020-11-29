using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ManageCloudDevices.Controllers
{
    public abstract class ManageCloudDevicesControllerBase: AbpController
    {
        protected ManageCloudDevicesControllerBase()
        {
            LocalizationSourceName = ManageCloudDevicesConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
