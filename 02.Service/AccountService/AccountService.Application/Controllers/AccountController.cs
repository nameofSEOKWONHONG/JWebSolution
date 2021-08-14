using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountService.Application.Controllers
{
    public class AccountController : JControllerBase
    {
        private readonly IGetAccountService _getAccountService;

        public AccountController(ILogger<AccountController> logger, 
            IGetAccountService getAccountService) : base(logger)
        {       
            _getAccountService = getAccountService;
        }

        [HttpGet]
        public async Task<ACCOUNT> GetAccount(long uid)
        {
            return await SerivceExecuteAsync<IGetAccountService, long, ACCOUNT>(_getAccountService, uid);
        }
    }
}