using System.Collections.Generic;
using Entity;
using JServiceStack.Service;

namespace AccountService.Contract.Interfaces
{
    public interface IGetAccountService : IServiceExecutor<long, ACCOUNT>
    {
    }

    public interface IAccountService
    {
        LOGIN Get(long id);
        IEnumerable<LOGIN> Gets();
        bool Save(LOGIN item);
        bool Remove(long uid);
    }
}