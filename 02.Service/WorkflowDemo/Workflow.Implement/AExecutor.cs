using System.Collections.Generic;
using Entity;
using JServiceStack.Workflow;
using Mapster;
using Workflow.Contract;

namespace Workflow.Implement
{
    public class AExecutor : IAExecutor
    {
        public string Name => "Implement.AExecutor";
        public void Execute(RequestDataContext context)
        {
            var accounts = new List<ACCOUNT>()
            {
                new ACCOUNT()
                {
                    ID = 1,
                    NAME = "test",
                    EMAIL = "test@test.com"
                },
                new ACCOUNT()
                {
                    ID = 2,
                    NAME = "test2",
                    EMAIL = "test2@test.com"
                }
            };
            
            context.Request.Add("accounts", accounts);
            var tempAccounts = context.Request["accounts"]
                .Adapt<IEnumerable<ACCOUNT>>();

            foreach (var account in tempAccounts)
            {
                context.Request.Add("account", account);
                var workflow = WorkflowManager.CreateWorkflow("Workflow", "GetSec");
                WorkflowManager.RunWorkFlow(workflow, context);
                context.Request.Remove("account");
            }
        }
    }
}