using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ApiTesting;

[Dependency(ReplaceServices = true)]
public class ApiTestingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ApiTesting";
}
