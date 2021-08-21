using System;
using System.Collections.Generic;
using Entity;
using eXtensionSharp;
using JServiceStack.Web;
using Mapster;
using Workflow.Contract;

namespace Workflow.Implement
{
    public class BExecutor : IBExecutor
    {
        public string Name => "Implement.BExecutor";
        public void Execute(RequestDataContext context)
        {
            var account = context.Request["account"].Adapt<ACCOUNT>();
            account.TEL = "111-2222-3333";
            context.Response.Add(account.ID.xGetValue(), account);
        }
    }
}