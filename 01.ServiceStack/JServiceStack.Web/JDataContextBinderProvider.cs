using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JServiceStack.Workflow;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace JServiceStack.Web
{
    public class JDataContextBinderProvider : IModelBinderProvider {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(RequestDataContext))
                return new JDataContextBinder();

            return null;
        }
    }
}