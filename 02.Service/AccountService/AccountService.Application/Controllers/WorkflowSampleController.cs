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
            context.ControllerName = ControllerContext.ActionDescriptor.ControllerName;
            context.ActionName = ControllerContext.ActionDescriptor.ActionName;
            context.Request["id"] = "";
            //or
            //context.Request["id"] = "test123";

            var t = typeof(AValidator);
            var workFlow = WorkFlowManager.CreateWorkFlow(context);
            // workFlow.AddValidator<IValidatorBase>();
            // workFlow.AddExecutor<IExecutorBase>();
            return WorkFlowManager.RunWorkFlow(workFlow, context);
        }
    }

    public interface IAValidator : IValidatorBase
    {
    }

    public class AValidator : IAValidator
    {
        public string Name => "AccountService.Application.Controllers.AValidator";

        public void Validate(JDataContext context)
        {
            var id = context.Request["id"].xSafe();
            if (id.xIsEmpty())
            {
                throw new Exception("id is empty.");
            }
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