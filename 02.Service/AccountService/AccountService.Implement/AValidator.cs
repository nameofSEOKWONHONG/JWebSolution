using System;
using AccountService.Contract.Interfaces;
using eXtensionSharp;
using JServiceStack.Web;

namespace AccountService.Implement
{
    public class AValidator : IAValidator
    {
        public string Name => "AccountService.Implement.AValidator";

        public void Validate(RequestDataContext context)
        {
            var id = context.Request["id"].xGetValue();
            if (id.xIsEmpty())
            {
                throw new Exception("id is empty.");
            }
        }
    }
}