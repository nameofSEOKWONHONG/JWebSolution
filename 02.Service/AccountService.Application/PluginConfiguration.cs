using AccountService.Contract.Interfaces;
using JServiceStack.Web;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Application
{
    public class PluginConfiguration : IPluginFactory
    {
        public void Configure(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService.Implement.AccountService>();
        }
    }
}