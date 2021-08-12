﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Contract.Interfaces;
using Entity;
using JServiceStack.Service;

namespace AccountService.Implement
{
    public class GetAccountService : ServiceExecutor<GetAccountService, long, ACCOUNT>,
        IGetAccountService
    {
        public override Task<bool> ValidateAsync()
        {
            return Task.FromResult(true);
        }

        public override async Task ExecuteAsync()
        {
            await Task.Run(() => this.Result = new ACCOUNT() {Id = 1, NAME = "test", TEL = "000-000-0000", EMAIL = "test@gmail.com", CreationDate = DateTime.Now});
        }
    }

    public class AccountService : IAccountService
    {
        private static readonly List<LOGIN> _logins = new();

        public LOGIN Get(long id)
        {
            return _logins.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<LOGIN> Gets()
        {
            return _logins;
        }

        public bool Save(LOGIN item)
        {
            var exists = _logins.FirstOrDefault(m => m.Id == item.Id);
            if (exists != null)
                //update
                exists.USER_NAME = exists.USER_NAME;

            _logins.Add(item);

            return true;
        }

        public bool Remove(long uid)
        {
            var exists = _logins.FirstOrDefault(m => m.Id == uid);
            if (exists != null)
            {
                _logins.Remove(exists);
                return true;
            }

            return false;
        }
    }
}