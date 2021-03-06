using JServiceStack.Web;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace AccountService.Application.Controllers
{
    public class LoginTokenController : JControllerBase
    {
        public LoginTokenController(ILogger logger, IMemoryCache memoryCache) : base(logger, memoryCache)
        {
        }
    }
}