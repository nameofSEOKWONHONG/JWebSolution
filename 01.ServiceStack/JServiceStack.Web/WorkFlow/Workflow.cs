using System;
using System.Collections.Generic;
using System.Transactions;
using eXtensionSharp;
using JServiceStack.Injection;
using Microsoft.Extensions.Options;

namespace JServiceStack.Web
{   
    /// <summary>
    /// 위크플로우 구현
    /// 워크플로우는 각 작업 단위를 묶어서 실행할 수 있도록 도와준다.
    /// N개의 Validator와
    /// N개의 Executor를 묶어서 처리할 수 있다.
    /// </summary>
    public class WorkflowBase : IWorkflowBase
    {
        private readonly List<IValidatorBase> _validatorBases = new List<IValidatorBase>();
        private readonly List<ExecutorCollection> _executorCollections = new List<ExecutorCollection>();

        public WorkflowBase()
        {
            
        }

        #region [Serivce Locator를 이용한 방법]

        public IWorkflowBase AddValidator<TValidator>() where TValidator : IValidatorBase
        {
            var validator = ServiceLocator.Current.GetInstance<TValidator>();
            _validatorBases.Add(validator);
            return this;
        }

        public IWorkflowBase AddExecutor<TExecutor>() where TExecutor : IExecutorBase
        {
            var executor = ServiceLocator.Current.GetInstance<TExecutor>();
            _executorCollections.Add(new ExecutorCollection()
            {
                NormalExecutor = executor,
                TransactionExecutors = null
            });
            return this;
        }

        #endregion

        #region [생성된 instance를 주입한 방법]
        public IWorkflowBase AddValidator(IValidatorBase validator)
        {
            _validatorBases.Add(validator);
            return this;            
        }

        public IWorkflowBase AddExecutor(IExecutorBase executor)
        {
            return AddExecutor(executor, null);
        }
        #endregion

        #region [transaction을 위한 방법]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="exeutors"></param>
        /// <returns></returns>
        public IWorkflowBase AddExecutor(IExecutorBase executor, IEnumerable<IExecutorBase> exeutors)
        {
            _executorCollections.Add(new ExecutorCollection()
            {
                NormalExecutor = executor,
                TransactionExecutors = exeutors
            });
            return this;
        }

        #endregion


        /// <summary>
        /// 실행
        /// </summary>
        /// <param name="context"></param>
        public void Execute(RequestDataContext context)
        {
            _validatorBases.xForEach(validator => validator.Validate(context));
            _executorCollections.xForEach(executors =>
            {
                executors.NormalExecutor.Execute(context);
                using (var scope = new TransactionScope())
                {
                    executors.TransactionExecutors.xForEach(next =>
                    {
                        next.Execute(context);
                    });
                    scope.Complete();
                }
            });
        }
    }

    internal class ExecutorCollection
    {
        /// <summary>
        /// 하나의 Executor만 실행함.
        /// </summary>
        public IExecutorBase NormalExecutor { get; set; }
        
        /// <summary>
        /// 복수의 Executor를 하나의 Transaction내에서 처리함.
        /// </summary>
        public IEnumerable<IExecutorBase> TransactionExecutors { get; set; }
    }
}