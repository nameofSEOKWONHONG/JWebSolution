using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class GetsAccountService : ServiceExecutor<GetsAccountService, ACCOUNT, IEnumerable<ACCOUNT>>, IGetsAccountService
    {
        public override Task<bool> ValidateAsync()
        {
            return base.ValidateAsync();
        }

        public override Task ExecuteAsync()
        {
            return base.ExecuteAsync();
        }
    }
}