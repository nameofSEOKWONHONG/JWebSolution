using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public class ServiceExecutor<TRequest, TResult> : ServiceBase, IServiceExecutor<TRequest, TResult>
    {
        protected ServiceExecutor()
        {
        }

        public TRequest Request { get; set; }
        public TResult Result { get; set; }

        public override void Dispose()
        {
        }
        
        public override Task<bool> ExecutingAsync()
        {
            return Task.FromResult(true);
        }

        public override Task ExecuteAsync()
        {
            return Task.CompletedTask;
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