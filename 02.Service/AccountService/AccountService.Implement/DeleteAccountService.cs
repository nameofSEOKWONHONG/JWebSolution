using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class DeleteAccountService : ServiceExecutor<long, bool>, IDeleteAccountService
    {
        public override Task ExecuteAsync()
        {
            return base.ExecuteAsync();
        }
    }
}