using AbpSevenDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpSevenDemo.Permissions;

public class AbpSevenDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpSevenDemoPermissions.GroupName);

        myGroup.AddPermission(AbpSevenDemoPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(AbpSevenDemoPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpSevenDemoPermissions.MyPermission1, L("Permission:MyPermission1"));

        var customerPermission = myGroup.AddPermission(AbpSevenDemoPermissions.Customers.Default, L("Permission:Customers"));
        customerPermission.AddChild(AbpSevenDemoPermissions.Customers.Create, L("Permission:Create"));
        customerPermission.AddChild(AbpSevenDemoPermissions.Customers.Edit, L("Permission:Edit"));
        customerPermission.AddChild(AbpSevenDemoPermissions.Customers.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpSevenDemoResource>(name);
    }
}