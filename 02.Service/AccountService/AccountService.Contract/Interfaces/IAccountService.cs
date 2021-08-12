using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using JServiceStack.Service;

namespace AccountService.Contract.Interfaces
{
    
    public interface IGetAccountService : IServiceExecutor<long, ACCOUNT>
    {
    }

    public interface IGetsAccountService : IServiceExecutor<ACCOUNT, IEnumerable<ACCOUNT>>
    {
    }
    
    public interface ISaveAccountService : IServiceExecutor<ACCOUNT, bool>
    {
    }

    public interface IDeleteAccountService : IServiceExecutor<long, bool>
    {
    }
}