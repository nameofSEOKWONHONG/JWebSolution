namespace JServiceStack.Service
{
    public interface IServiceExecutor<TRequest, TResult> : IServiceBase
    {
        TRequest Request { get; set; }
        TResult Result { get; set; }
    }
}