using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public abstract class ServiceBase<TResult> : IServiceBase
    {
        public abstract void Dispose();
        public abstract Task<bool> ValidateAsync();
        public abstract Task<bool> ExecutingAsync();
        public abstract Task<object> ExecuteAsync();
        public abstract Task ExecutedAsync();
    }
}