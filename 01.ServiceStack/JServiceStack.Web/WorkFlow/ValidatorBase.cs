using System.Security;

namespace JServiceStack.Web
{
    public interface IValidatorBase
    {
        void Validate(JDataContext context);
    }

    public abstract class ValidatorBase : IValidatorBase
    {
        public virtual void Validate(JDataContext context)
        {
            
        }
    }
}