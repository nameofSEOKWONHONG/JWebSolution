using System;
using System.Collections.Generic;
using eXtensionSharp;
using JServiceStack.Injection;

namespace JServiceStack.Web
{

    
    /// <summary>
    /// 아래의 코드가 Setup > ConfigureServices에 선언되어 있어야 함.
    /// ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
    /// </summary>
    public class WorkFlowBase : IWorkFlowBase
    {
        private readonly List<IValidatorBase> _validatorBases = new List<IValidatorBase>();
        private readonly List<IExecutorBase> _executorBases = new List<IExecutorBase>();

        public WorkFlowBase()
        {
            
        }

        public IWorkFlowBase AddValidator<TValidator>() where TValidator : IValidatorBase
        {
            var validator = ServiceLocator.Current.GetInstance<TValidator>();
            _validatorBases.Add(validator);
            return this;
        }

        public IWorkFlowBase AddValidator(Type serviceType)
        {
            var validator = (IValidatorBase)ServiceLocator.Current.GetInstance(serviceType);
            _validatorBases.Add(validator);
            return this;            
        }

        public IWorkFlowBase AddExecutor<TExecutor>() where TExecutor : IExecutorBase
        {
            var executor = ServiceLocator.Current.GetInstance<TExecutor>();
            _executorBases.Add(executor);
            return this;
        }

        public IWorkFlowBase AddExecutor(Type serviceType)
        {
            var executor = (IExecutorBase)ServiceLocator.Current.GetInstance(serviceType);
            _executorBases.Add(executor);
            return this;
        }

        public void Execute(JDataContext context)
        {
            _validatorBases.xForEach(validator => validator.Validate(context));
            _executorBases.xForEach(executor => executor.Execute(context));
        }
    }
}