namespace JServiceStack.Workflow
{
    public interface IWorkflowBase
    {
        IWorkflowBase AddValidator<TValidator>() where TValidator : IValidatorBase;
        IWorkflowBase AddExecutor<TExecutor>() where TExecutor : IExecutorBase;
        IWorkflowBase AddValidator(IValidatorBase validator);  
        IWorkflowBase AddExecutor(IExecutorBase executor);
    }
}