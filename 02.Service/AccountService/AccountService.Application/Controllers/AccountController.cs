using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountService.Application.Controllers
{
    public class AccountController : JContollerBase
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
            return await ExecuteSerivceAsync<IGetAccountService, long, ACCOUNT>(_getAccountService, uid);
        }
    }
}