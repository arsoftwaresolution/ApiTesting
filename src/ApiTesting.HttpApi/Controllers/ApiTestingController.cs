using ApiTesting.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ApiTesting.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ApiTestingController : AbpControllerBase
{
    protected ApiTestingController()
    {
        LocalizationResource = typeof(ApiTestingResource);
    }
}
