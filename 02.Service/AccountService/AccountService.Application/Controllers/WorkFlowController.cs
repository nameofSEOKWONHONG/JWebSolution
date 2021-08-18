using System;
using eXtensionSharp;
using JServiceStack.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace AccountService.Application.Controllers
{
    public class WorkFlowController : JControllerBase
    {
        public WorkFlowController(ILogger<WorkFlowController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Sample()
        {
            var context = new JDataContext();
            context.Request["id"] = "";
            //or
            //context.Request["id"] = "test123";

            var workFlow = WorkFlowManager.CreateWorkFlow();
            workFlow.AddValidator<IValidatorBase>();
            workFlow.AddExecutor<IExecutorBase>();
            return WorkFlowManager.RunWorkFlow(workFlow, context);
        }
    }
    
    public class AValidator : IValidatorBase
    {
        public void Validate(JDataContext context)
        {
            var id = context.Request["id"].xSafe();
            if (id.xIsEmpty())
            {
                throw new Exception("id is empty.");
            }
        }
    }

    public class AExecutor : IExecutorBase
    {
        public void Execute(JDataContext context)
        {
            context.Response["returnId"] = "test";
        }
    }
}