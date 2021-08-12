using System.Threading.Tasks;
using JServiceStack.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace JServiceStack.Web
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JContollerBase : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IMemoryCache MemoryCache;

        public JContollerBase(ILogger logger)
        {
            Logger = logger;
        }

        public JContollerBase(ILogger logger, IMemoryCache memoryCache)
        {
            Logger = logger;
            MemoryCache = memoryCache;
        }

        public async Task<TResult> ExecuteSerivceAsync<TService, TRequest, TResult>(TService service, TRequest request)
            where TService : IServiceBase
        {
            var rlt = default(TResult);
            var serviceExecutor = new ServiceExecutorManager<TService>(service);
            rlt = await serviceExecutor.ExecuteAsync<TResult>();
            return rlt;
        }
    }
}