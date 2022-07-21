using ApiTesting.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ApiTesting.Permissions;

public class ApiTestingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ApiTestingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ApiTestingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ApiTestingResource>(name);
    }
}
