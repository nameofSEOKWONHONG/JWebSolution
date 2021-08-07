using AccountService.Contract.Interfaces;
using JServiceStack.WebApiBase;
using Microsoft.Extensions.DependencyInjection;

namespace AccountPlugin
{
    public class PluginConfiguration : IPluginFactory
    {
        public void Configure(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService.Implement.AccountService>();
        }
    }
}