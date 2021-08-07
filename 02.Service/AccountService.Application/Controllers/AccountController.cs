using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiBase;

namespace AccountPlugin.Controllers
{
    public class AccountController : JContollerBase
    {
        private readonly IAccountService _accountSvc;
        private readonly IGetAccountService _getAccountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountSvc,
            IGetAccountService getAccountService) : base(logger)
        {
            _accountSvc = accountSvc;
            _getAccountService = getAccountService;
        }

        [HttpGet]
        public async Task<bool> GetUser(int uid)
        {
            return await ExecuteSerivceAsync<IGetAccountService, int, bool>(_getAccountService, uid);
        }
    }
}