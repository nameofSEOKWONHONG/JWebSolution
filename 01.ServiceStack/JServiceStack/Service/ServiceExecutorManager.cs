using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public class ServiceExecutorManager<TServiceBase>
        where TServiceBase : IServiceBase
    {
        private readonly TServiceBase _service;

        public ServiceExecutorManager(TServiceBase service)
        {
            _service = service;
        }

        public async Task<TResult> ExecuteAsync<TResult>()
        {
            var result = default(TResult);
            var valid = await _service.ValidateAsync();
            if (valid)
            {
                var ing = await _service.ExecutingAsync();
                if (ing)
                {
                    result = (TResult) await _service.ExecuteAsync();
                    await _service.ExecutedAsync();
                }
            }

            return result;
        }
    }
}