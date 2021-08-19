using System;
using eXtensionSharp;
using JServiceStack.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace AccountService.Application.Controllers
{
    public class WorkflowSampleController : JControllerBase
    {
        public WorkflowSampleController(ILogger<WorkflowSampleController> logger) : base(logger)
        {
        }

        [HttpPost]
        public IActionResult Sample(JDataContext context)
        {
            var workFlow = WorkFlowManager.CreateWorkFlow(context);
            // workFlow.AddValidator<IValidatorBase>();
            // workFlow.AddExecutor<IExecutorBase>();
            return WorkFlowManager.RunWorkFlow(workFlow, context);
        }
    }



    public interface IAExecutor : IExecutorBase
    {
    }

    public class AExecutor : IAExecutor
    {
        public string Name => "AccountService.Application.Controllers.AExecutor";
        public void Execute(JDataContext context)
        {
            context.Response["returnId"] = "test";
        }
    }
}