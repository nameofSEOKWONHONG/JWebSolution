using System.Collections.Generic;
using eXtensionSharp;

namespace JServiceStack.Web
{
    public class RequestDataContext
    {
        public DynamicDictionary<object> Request { get; set; } = new DynamicDictionary<object>();
        public DynamicDictionary<object> Response { get; set; } = new DynamicDictionary<object>();
        public DynamicDictionary<string> ValidateResult { get; set; } = new DynamicDictionary<string>();
        public string WorkflowName { get; set; }
        public string WorkflowJsonName { get; set; }
    }
}