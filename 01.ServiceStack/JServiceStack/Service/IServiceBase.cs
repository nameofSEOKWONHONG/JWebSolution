using System;
using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public interface IServiceBase<TResult> : IDisposable
    {
        Task<bool> ValidateAsync();
        Task<bool> ExecutingAsync();
        Task<TResult> ExecuteAsync();
        Task ExecutedAsync();
    }
}