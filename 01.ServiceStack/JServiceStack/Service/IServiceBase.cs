﻿using System;
using System.Threading.Tasks;

namespace JServiceStack.Service
{
    public interface IServiceBase : IDisposable
    {
        Task<bool> ValidateAsync();
        Task<bool> ExecutingAsync();
        Task<object> ExecuteAsync();
        Task ExecutedAsync();
    }
}