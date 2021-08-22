using System.Threading.Tasks;
using JServiceStack.Web;
using JServiceStack.Workflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Workflow.Application.Controllers
{
    public class WorkflowController : JControllerBase
    {
        public WorkflowController(ILogger<WorkflowController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Get(RequestDataContext dataContext)
        {
            var workflow = WorkflowManager.CreateWorkFlow(dataContext);
            return await RunWorkflowAsync(workflow, dataContext);
        }
    }
}