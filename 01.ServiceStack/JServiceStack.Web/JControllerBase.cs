using System.Threading.Tasks;
using JServiceStack.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace JServiceStack.Web
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JControllerBase : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IMemoryCache MemoryCache;

        public JControllerBase(ILogger logger)
        {
            Logger = logger;
        }

        public JControllerBase(ILogger logger, IMemoryCache memoryCache)
        {
            Logger = logger;
            MemoryCache = memoryCache;
        }

        protected async Task<TResult> SerivceExecuteAsync<TService, TRequest, TResult>(TService service, TRequest request)
            where TService : IServiceBase<TResult>
        {
            var rlt = default(TResult);
            var serviceExecutor = new ServiceExecutorManager<TService, TResult>(service);
            rlt = await serviceExecutor.ExecuteAsync();
            return rlt;
        }
    }


}