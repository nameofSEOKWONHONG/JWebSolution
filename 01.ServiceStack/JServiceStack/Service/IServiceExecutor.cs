namespace JServiceStack.Service
{
    public interface IServiceExecutor<TRequest, TResult> : IServiceBase<TResult>
    {
        TRequest Request { get; set; }
    }
}