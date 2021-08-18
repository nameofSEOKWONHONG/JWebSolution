using Microsoft.AspNetCore.Mvc;

namespace JServiceStack.Web
{
    public class WorkFlowManager
    {
        private WorkFlowManager()
        {
            
        }

        public static IWorkFlowBase CreateWorkFlow()
        {
            var workflow = new WorkFlowBase();
            return workflow;
        }

        public static IActionResult RunWorkFlow(IWorkFlowBase workflow, JDataContext context)
        {
            ((WorkFlowBase)workflow).Execute(context);
            var okResult = new OkObjectResult(context.Response);
            return okResult;
        }
    }
}