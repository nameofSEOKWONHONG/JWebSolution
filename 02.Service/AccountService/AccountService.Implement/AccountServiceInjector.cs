using System;
using AccountService.Contract.Interfaces;
using JServiceStack.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Implement
{
    public class AccountServiceInjector : IServiceInjector
    {
        public string Name => "AccountService.Implement.AccountServiceInjector";

        public void Register(IServiceCollection services)
        { 
            services.AddSingleton<IGetAccountService, GetAccountService>();
            services.AddSingleton<IGetsAccountService, GetsAccountService>();
            services.AddSingleton<ISaveAccountService, SaveAccountService>();
            services.AddSingleton<IDeleteAccountService, DeleteAccountService>();
        }
    }
}