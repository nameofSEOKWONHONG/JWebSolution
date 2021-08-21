using System;
using eXtensionSharp;
using JServiceStack.Web;
using Workflow.Contract;

namespace Workflow.Implement
{
    public class AValidator : IAValidator
    {
        public string Name => "Implement.AValidator";
        public void Validate(RequestDataContext context)
        {
            var userid = context.Request["user_id"].xGetValue();
            if (userid.xIsEmpty())
            {
                context.ValidateResult.Add("AValidator Error", "userid is empty.");
            }
        }
    }
}