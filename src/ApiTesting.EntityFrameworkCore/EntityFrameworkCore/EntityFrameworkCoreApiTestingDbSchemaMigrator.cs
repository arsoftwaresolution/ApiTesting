using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiTesting.Data;
using Volo.Abp.DependencyInjection;

namespace ApiTesting.EntityFrameworkCore;

public class EntityFrameworkCoreApiTestingDbSchemaMigrator
    : IApiTestingDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreApiTestingDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ApiTestingDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ApiTestingDbContext>()
            .Database
            .MigrateAsync();
    }
}
