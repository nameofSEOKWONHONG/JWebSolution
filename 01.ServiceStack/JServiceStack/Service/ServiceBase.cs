using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public abstract class ServiceBase : IServiceBase
    {
        public abstract void Dispose();
        public abstract Task<bool> ExecutingAsync();
        public abstract Task ExecuteAsync();
        public abstract Task ExecutedAsync();

        public abstract Task OnFailedAsync();
    }
}