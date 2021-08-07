using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using WebApiBase;

namespace AccountPlugin.Controllers
{
    public class LoginTokenController : JContollerBase
    {
        public LoginTokenController(ILogger logger, IMemoryCache memoryCache) : base(logger, memoryCache)
        {
        }
    }
}