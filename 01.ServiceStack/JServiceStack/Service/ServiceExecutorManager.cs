using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public class ServiceExecutorManager<TServiceBase, TRequest, TResult>
        where TServiceBase : IServiceBase
    {
        private readonly TServiceBase _service;
        private readonly TRequest _request;

        public ServiceExecutorManager(TServiceBase service, TRequest request)
        {
            _service = service;
            _request = request;
        }

        public async Task<TResult> ExecuteAsync()
        {
            ((IServiceExecutor<TRequest, TResult>)_service).Request = this._request;

            var ing = await _service.ExecutingAsync();
            if (ing)
            {
                await _service.ExecuteAsync();
                await _service.ExecutedAsync();
            }

            var result = ((IServiceExecutor<TRequest, TResult>)_service).Result;

            return result;
        }
    }
}