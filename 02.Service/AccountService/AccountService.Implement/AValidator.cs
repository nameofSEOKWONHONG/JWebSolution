using System;
using AccountService.Contract.Interfaces;
using eXtensionSharp;
using JServiceStack.Web;

namespace AccountService.Implement
{
    public class AValidator : IAValidator
    {
        public string Name => "AccountService.Implement.AValidator";

        public void Validate(JDataContext context)
        {
            var id = context.Request["id"].xSafe();
            if (id.xIsEmpty())
            {
                throw new Exception("id is empty.");
            }
        }
    }
}