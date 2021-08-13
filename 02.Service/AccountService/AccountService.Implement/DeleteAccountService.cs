using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class DeleteAccountService : ServiceExecutor<DeleteAccountService, long, bool>, IDeleteAccountService
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