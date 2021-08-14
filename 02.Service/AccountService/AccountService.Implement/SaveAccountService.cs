using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class SaveAccountService : ServiceExecutor<ACCOUNT, bool>, ISaveAccountService
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