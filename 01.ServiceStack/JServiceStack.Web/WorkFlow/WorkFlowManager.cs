using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using eXtensionSharp;
using JServiceStack.Injection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace JServiceStack.Web
{
    public class WorkFlowManager
    {
        private WorkFlowManager()
        {
            
        }

        public static IWorkFlowBase CreateWorkFlow()
        {
            var workflow = new WorkFlowBase();
            return workflow;
        }

        private static List<Assembly> _contractDlls = new List<Assembly>();

        public static IWorkFlowBase CreateWorkFlow(JDataContext context)
        {
            var workflow = new WorkFlowBase();

            if (_contractDlls.xIsEmpty())
            {
                var contractFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");
                contractFiles.xForEach(item =>
                {
                    if (item.Contains(".Implement"))
                    {
                        _contractDlls.Add(Assembly.LoadFile(item));
                    }
                });                
            }


            //var env = ServiceLocator.Current.GetInstance<IHostEnvironment>();
            //var workflowJsonPath = Path.Combine(env.ContentRootPath, $"/Workflow/{context.ControllerName}/{context.ActionName}");
            var workflowJsonPath = $".\\Workflow\\{context.ControllerName}\\{context.ActionName}.json";
            var text = workflowJsonPath.xFileReadAllText();
            var dto = text.xToEntity<WorkFlowDto>();
            dto.Validators.xForEach(v =>
            {
                var assembly = _contractDlls.FirstOrDefault();
                var type = (IValidatorBase)assembly.CreateInstance(v);
                workflow.AddValidator(type);
            });
            dto.Executors.xForEach(e =>
            {
                
            });

            return workflow;
        }

        private static Type CreateType(string ns)
        {
            var type = Type.GetType(ns);
            if (type.xIsEmpty()) 
                throw new DllNotFoundException($"{ns} not found.");

            return type;
        }

        public static IActionResult RunWorkFlow(IWorkFlowBase workflow, JDataContext context)
        {
            ((WorkFlowBase)workflow).Execute(context);
            var okResult = new OkObjectResult(context.Response);
            return okResult;
        }
    }

    public class AssemblyLoader
    {
        public static Assembly LoadFile(string path)
        {
            return Assembly.LoadFile(path);
        }
    }

    public class WorkFlowDto
    {
        public string[] Validators { get; set; }
        public string[] Executors { get; set; }
    }
}