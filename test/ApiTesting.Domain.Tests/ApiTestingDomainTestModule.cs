using ApiTesting.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ApiTesting;

[DependsOn(
    typeof(ApiTestingEntityFrameworkCoreTestModule)
    )]
public class ApiTestingDomainTestModule : AbpModule
{

}
