using Volo.Abp.Modularity;

namespace ApiTesting;

[DependsOn(
    typeof(ApiTestingApplicationModule),
    typeof(ApiTestingDomainTestModule)
    )]
public class ApiTestingApplicationTestModule : AbpModule
{

}
