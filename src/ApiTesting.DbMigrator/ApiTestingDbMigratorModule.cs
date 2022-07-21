using ApiTesting.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ApiTesting.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ApiTestingEntityFrameworkCoreModule),
    typeof(ApiTestingApplicationContractsModule)
    )]
public class ApiTestingDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
