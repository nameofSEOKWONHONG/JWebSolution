﻿using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class LoginService : ServiceExecutor<LoginService, ACCOUNT, bool>, ILoginService
    {
        public override Task<bool> ValidateAsync()
        {
            return base.ValidateAsync();
        }

        public override Task<bool> ExecuteAsync()
        {
            return base.ExecuteAsync();
        }
    }
}