using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using eXtensionSharp;

namespace JServiceStack.Workflow
{
    /// <summary>
    ///     동적 Instance를 생성하고 workflow json파일을 읽어 작업 단위를 생성한다.
    /// </summary>
    internal class WorkflowLoader
    {
        private static readonly Lazy<WorkflowLoader> _instance = new(() => new WorkflowLoader());

        private readonly List<Assembly> _contractDlls = new();

        private WorkflowLoader()
        {
            LoadDll();
        }

        public static WorkflowLoader Instance => _instance.Value;

        public void Load(RequestDataContext dataContext, Action<IValidatorBase> vRegisterAction,
            Action<IExecutorBase, IEnumerable<IExecutorBase>> eRegisterAction)
        {
            LoadWorkflow(dataContext.WorkflowName, dataContext.WorkflowJsonName, vRegisterAction, eRegisterAction);
        }

        public void Load(string workflowName, string workflowJsonName, Action<IValidatorBase> vRegisterAction,
            Action<IExecutorBase, IEnumerable<IExecutorBase>> eRegisterAction)
        {
            LoadWorkflow(workflowName, workflowJsonName, vRegisterAction, eRegisterAction);
        }


        private void LoadDll()
        {
            if (_contractDlls.xIsEmpty())
            {
                var contractFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");
                contractFiles.xForEach(item =>
                {
                    if (item.Contains(".Implement")) _contractDlls.Add(Assembly.LoadFile(item));
                });
            }
        }

        /// <summary>
        /// 실행할 workflow를 명시적으로 선언한다.
        /// </summary>
        /// <param name="workflowName"></param>
        /// <param name="workflowJsonName"></param>
        /// <param name="vRegisterAction"></param>
        /// <param name="eRegisterAction"></param>
        private void LoadWorkflow(string workflowName, string workflowJsonName, Action<IValidatorBase> vRegisterAction,
            Action<IExecutorBase, IEnumerable<IExecutorBase>> eRegisterAction)
        {
            var workflowJsonPath = $".\\Workflows\\{workflowName}\\{workflowJsonName}.json";
            var text = workflowJsonPath.xFileReadAllText();
            var entities = text.xToEntity<WorkflowEntity>();

            entities.Validators.xForEach(v =>
            {
                _contractDlls.xForEach(dll =>
                {
                    var exists = dll.GetTypes().FirstOrDefault(m => m.FullName.Contains(v));
                    if (exists != null)
                    {
                        var validator = (IValidatorBase)dll.CreateInstance(exists.FullName);
                        vRegisterAction(validator);
                        return false;
                    }

                    return true;
                });
            });

            IExecutorBase mainExecutor = null;
            var tranExecutors = new List<IExecutorBase>();

            entities.Executors.xForEach(e =>
            {
                mainExecutor = FindExecutor(e.Executor, _contractDlls);

                e.Executors.xForEach(texecutor =>
                {
                    var executor = FindExecutor(texecutor, _contractDlls);
                    tranExecutors.Add(executor);
                });
            });

            eRegisterAction(mainExecutor, tranExecutors);
        }

        private IExecutorBase FindExecutor(string name, IEnumerable<Assembly> assemblies)
        {
            IExecutorBase find = null;

            assemblies.xForEach(assembly =>
            {
                var exists = assembly.GetTypes()
                    .FirstOrDefault(m => m.FullName.Contains(name));

                if (exists != null)
                {
                    find = (IExecutorBase)assembly.CreateInstance(exists.FullName);
                    return false;
                }

                return true;
            });

            return find;
        }
    }
}