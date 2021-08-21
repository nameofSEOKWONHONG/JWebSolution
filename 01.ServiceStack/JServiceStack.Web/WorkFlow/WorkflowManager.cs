using Microsoft.AspNetCore.Mvc;

namespace JServiceStack.Web
{
    public class WorkflowManager
    {
        private WorkflowManager()
        {
        }

        public static IWorkflowBase CreateWorkFlow()
        {
            var workflow = new WorkflowBase();
            return workflow;
        }

        public static IWorkflowBase CreateWorkFlow(RequestDataContext context)
        {
            var workflow = new WorkflowBase();
            WorkflowLoader.Instance.Load(context, v => { workflow.AddValidator(v); },
                (e, elist) => { workflow.AddExecutor(e, elist); });
            return workflow;
        }

        public static IWorkflowBase CreateWorkflow(string worflowName, string workflowJsonName)
        {
            var workflow = new WorkflowBase();
            WorkflowLoader.Instance.Load(worflowName, workflowJsonName, v => { workflow.AddValidator(v); },
                (e, elist) => { workflow.AddExecutor(e, elist); });
            return workflow;
        }

        public static IActionResult RunWorkFlow(IWorkflowBase workflow, RequestDataContext context)
        {
            ((WorkflowBase)workflow).Execute(context);
            return new OkObjectResult(context.Response);
        }
    }
}