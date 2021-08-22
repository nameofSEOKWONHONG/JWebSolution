namespace JServiceStack.Workflow
{
    public interface IExecutorBase
    {
        string Name { get; }
        void Execute(RequestDataContext context);
    }
}