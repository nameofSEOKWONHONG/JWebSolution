using System.Security;

namespace JServiceStack.Web
{
    public interface IValidatorBase
    {
        string Name { get; }
        void Validate(RequestDataContext context);
    }
}