using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class GetAccountService : ServiceExecutor<GetAccountService, long, ACCOUNT>,
        IGetAccountService
    {
        public override Task<bool> ValidateAsync()
        {
            return Task.FromResult(true);
        }

        public override async Task<ACCOUNT> ExecuteAsync()
        {
            return await Task.Run(() => new ACCOUNT() {Id = 1, NAME = "test", TEL = "000-000-0000", EMAIL = "test@gmail.com", CreationDate = DateTime.Now});
        }
    }
}