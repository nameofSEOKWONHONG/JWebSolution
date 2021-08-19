using System.Security;

namespace JServiceStack.Web
{
    public interface IValidatorBase
    {
        string Name { get; }
        void Validate(JDataContext context);
    }

    public abstract class ValidatorBase : IValidatorBase
    {
        public virtual string Name { get; }
        public virtual void Validate(JDataContext context)
        {
            
        }
    }
}