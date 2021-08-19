namespace JServiceStack.Web
{
    public abstract class ExecutorBase : IExecutorBase
    {
        public string Name => "";
        public virtual void Execute(JDataContext context)
        {
            
        }
    } 
}