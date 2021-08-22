using System.Threading.Tasks;
using JServiceStack.Service;
using JServiceStack.Workflow;
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
            where TService : IServiceBase
        {
            var serviceExecutor = new ServiceExecutorManager<TService, TRequest, TResult>(service, request);
            var result = await serviceExecutor.ExecuteAsync();
            return result;
        }

        protected async Task<IActionResult> RunWorkflowAsync(IWorkflowBase workflow, RequestDataContext context)
        {
            return await Task.Run(() =>
            {
                ((WorkflowBase)workflow).Execute(context);
                return Ok(context.Response);
            });
        }
    }
}