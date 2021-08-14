using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using eXtensionSharp;
using JServiceStack.Service;
using RepoDb;

namespace AccountService.Implement
{
    public class GetAccountService : ServiceExecutor<long, ACCOUNT>,
        IGetAccountService
    {
        public override Task<bool> ValidateAsync()
        {
            return Task.FromResult(true);
        }

        public override async Task<ACCOUNT> ExecuteAsync()
        {
            return await Task.Run(() => new ACCOUNT()
                { ID = 1, NAME = "TEST", TEL = "000-000-0000", EMAIL = "TEST@gmail.com" });
            // var result = await base.DbExecutor<SqlConnection>()
            //     .ExecuteAsync(async db => await db.QueryAsync<ACCOUNT>(m => m.ID == this.Request));
            // return result.First();
        }

        public override Task ExecutedAsync()
        {
            return Task.CompletedTask;
        }
    }
}