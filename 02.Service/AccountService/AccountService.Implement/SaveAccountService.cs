using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class SaveAccountService : ServiceExecutor<ACCOUNT, bool>, ISaveAccountService
    {
        public override Task ExecuteAsync()
        {
            return base.ExecuteAsync();
        }
    }
}