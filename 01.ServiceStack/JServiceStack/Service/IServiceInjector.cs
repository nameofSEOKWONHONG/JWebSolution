using System;
using Microsoft.Extensions.DependencyInjection;

namespace JServiceStack.Service
{
    public interface IServiceInjector
    {
        string Name { get; }
        void Register(IServiceCollection services);
        
    }
}