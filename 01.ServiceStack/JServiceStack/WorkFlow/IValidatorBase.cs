namespace JServiceStack.Workflow
{
    public interface IValidatorBase
    {
        string Name { get; }
        void Validate(RequestDataContext context);
    }
}