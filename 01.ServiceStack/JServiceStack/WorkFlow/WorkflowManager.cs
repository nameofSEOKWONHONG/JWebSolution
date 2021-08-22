namespace JServiceStack.Workflow
{
    public class WorkflowManager
    {
        private WorkflowManager()
        {
        }

        /// <summary>
        /// workflow를 수동으로 생성합니다.
        /// Validator와 Executor를 수동으로 등록 할 수 있습니다.
        /// </summary>
        /// <returns></returns>
        public static IWorkflowBase CreateWorkFlow()
        {
            var workflow = new WorkflowBase();
            return workflow;
        }

        /// <summary>
        /// 표준 workflow입니다.
        /// validator와 executor생성을 controller, action명에 위임합니다.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IWorkflowBase CreateWorkFlow(RequestDataContext context)
        {
            var workflow = new WorkflowBase();
            WorkflowLoader.Instance.Load(context, v => { workflow.AddValidator(v); },
                (e, elist) => { workflow.AddExecutor(e, elist); });
            return workflow;
        }

        /// <summary>
        /// 수동으로 workflow를 생성합니다.
        /// 사용자가 직접 workflow를 지정하여 생성합니다.
        /// </summary>
        /// <param name="worflowName"></param>
        /// <param name="workflowJsonName"></param>
        /// <returns></returns>
        public static IWorkflowBase CreateWorkflow(string worflowName, string workflowJsonName)
        {
            var workflow = new WorkflowBase();
            WorkflowLoader.Instance.Load(worflowName, workflowJsonName, v => { workflow.AddValidator(v); },
                (e, elist) => { workflow.AddExecutor(e, elist); });
            return workflow;
        }

        /// <summary>
        /// 수동으로 사용할 경우 workflow를 실행합니다.
        /// 기본 controller인 JControllerBase에서는 protected로 구현되어 있습니다.
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="context"></param>
        public static void RunWorkFlow(IWorkflowBase workflow, RequestDataContext context)
        {
            ((WorkflowBase)workflow).Execute(context);
        }
    }
}