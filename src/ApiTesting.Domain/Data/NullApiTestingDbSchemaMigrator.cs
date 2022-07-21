using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ApiTesting.Data;

/* This is used if database provider does't define
 * IApiTestingDbSchemaMigrator implementation.
 */
public class NullApiTestingDbSchemaMigrator : IApiTestingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
