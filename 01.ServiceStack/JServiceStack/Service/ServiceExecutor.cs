using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public class ServiceExecutor<TOwner, TRequest, TResult> : ServiceBase<TResult>, IServiceExecutor<TRequest, TResult>
        where TOwner : ServiceExecutor<TOwner, TRequest, TResult>
    {
        protected readonly TOwner Owner;

        public ServiceExecutor()
        {
            Owner = (TOwner) this;
        }

        public TRequest Request { get; set; }
        public TResult Result { get; set; }

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

        public override Task<object> ExecuteAsync()
        {
            return null;
        }

        public override Task ExecutedAsync()
        {
            return Task.CompletedTask;
        }
    }
}