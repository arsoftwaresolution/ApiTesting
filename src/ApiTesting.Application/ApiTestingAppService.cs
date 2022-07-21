using System;
using System.Collections.Generic;
using System.Text;
using ApiTesting.Localization;
using Volo.Abp.Application.Services;

namespace ApiTesting;

/* Inherit your application services from this class.
 */
public abstract class ApiTestingAppService : ApplicationService
{
    protected ApiTestingAppService()
    {
        LocalizationResource = typeof(ApiTestingResource);
    }
}
