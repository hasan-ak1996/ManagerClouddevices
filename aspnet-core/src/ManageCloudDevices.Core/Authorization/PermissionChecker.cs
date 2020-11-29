using Abp.Authorization;
using ManageCloudDevices.Authorization.Roles;
using ManageCloudDevices.Authorization.Users;

namespace ManageCloudDevices.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
