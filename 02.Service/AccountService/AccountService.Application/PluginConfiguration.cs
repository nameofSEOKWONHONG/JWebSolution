using AccountService.Contract.Interfaces;
using AccountService.Implement;
using eXtensionSharp;
using JServiceStack.Service;
using JServiceStack.Web;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Application
{
    public class PluginConfiguration : IPluginFactory
    {
        private readonly IServiceInjector[] _serviceInjectors = {
            new AccountServiceInjector()
        };
        
        public void Configure(IServiceCollection services)
        {
            _serviceInjectors.xForEach(injector =>
            {
                injector.Register(services);
            });
        }
    }
}