using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace JServiceStack.Web
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class JVersionControllerBase : JControllerBase
    {
        public JVersionControllerBase(ILogger logger) : base(logger)
        {
        }

        public JVersionControllerBase(ILogger logger, IMemoryCache memoryCache) : base(logger, memoryCache)
        {
        }
    }
}