using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using eXtensionSharp;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace JServiceStack.Web
{
    public class JDataContextBinder : IModelBinder {
        public Task BindModelAsync(ModelBindingContext bindingContext) {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var controllerName = bindingContext.HttpContext.GetRouteData().Values["controller"];
            var actionName = bindingContext.HttpContext.GetRouteData().Values["action"];
            var dataContext = new RequestDataContext();
            dataContext.WorkflowName = controllerName.xGetValue();
            dataContext.WorkflowJsonName = actionName.xGetValue();
            bindingContext.Result = ModelBindingResult.Success(dataContext);
            return Task.CompletedTask;
        }
    }
}