using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public abstract class ServiceBase<TResult> : IServiceBase<TResult>
    {
        public abstract void Dispose();
        public abstract Task<bool> ValidateAsync();
        public abstract Task<bool> ExecutingAsync();
        public abstract Task<TResult> ExecuteAsync();
        public abstract Task ExecutedAsync();

        public abstract Task OnFailedAsync();
    }
}