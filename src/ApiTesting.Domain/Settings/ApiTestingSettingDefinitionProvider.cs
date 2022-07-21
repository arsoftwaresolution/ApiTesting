using Volo.Abp.Settings;

namespace ApiTesting.Settings;

public class ApiTestingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ApiTestingSettings.MySetting1));
    }
}
