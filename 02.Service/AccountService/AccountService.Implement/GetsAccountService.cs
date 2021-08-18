using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class GetsAccountService : ServiceExecutor<ACCOUNT, IEnumerable<ACCOUNT>>, IGetsAccountService
    {
        public override Task ExecuteAsync()
        {
            return base.ExecuteAsync();
        }
    }
}