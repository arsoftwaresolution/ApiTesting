using System.Threading.Tasks;

namespace ApiTesting.Data;

public interface IApiTestingDbSchemaMigrator
{
    Task MigrateAsync();
}
