using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public class ServiceExecutor<TRequest, TResult> : ServiceBase<TResult>, IServiceExecutor<TRequest, TResult>
    {
        protected ServiceExecutor()
        {
        }

        public TRequest Request { get; set; }

        public override void Dispose()
        {
        }

        public override Task<bool> ValidateAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> ExecutingAsync()
        {
            return Task.FromResult(true);
        }

        public override Task<TResult> ExecuteAsync()
        {
            return null;
        }

        public override Task ExecutedAsync()
        {
            return Task.CompletedTask;
        }

        public override Task OnFailedAsync()
        {
            return Task.CompletedTask;
        }
    }
}