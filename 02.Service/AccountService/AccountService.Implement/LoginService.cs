using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class LoginService : ServiceExecutor<ACCOUNT, bool>, ILoginService
    {
        public override Task ExecuteAsync()
        {
            return base.ExecuteAsync();
        }
    }
}