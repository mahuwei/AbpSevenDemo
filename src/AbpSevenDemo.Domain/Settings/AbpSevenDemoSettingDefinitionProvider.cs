using Volo.Abp.Settings;

namespace AbpSevenDemo.Settings;

public class AbpSevenDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpSevenDemoSettings.MySetting1));
    }
}
