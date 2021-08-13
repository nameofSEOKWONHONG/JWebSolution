using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public class ServiceExecutorManager<TServiceBase, TResult>
        where TServiceBase : IServiceBase<TResult>
    {
        private readonly TServiceBase _service;

        public ServiceExecutorManager(TServiceBase service)
        {
            _service = service;
        }

        public async Task<TResult> ExecuteAsync()
        {
            var result = default(TResult);
            var valid = await _service.ValidateAsync();
            if (valid)
            {
                var ing = await _service.ExecutingAsync();
                if (ing)
                {
                    result = await _service.ExecuteAsync();
                    await _service.ExecutedAsync();
                }
            }

            return result;
        }
    }
}