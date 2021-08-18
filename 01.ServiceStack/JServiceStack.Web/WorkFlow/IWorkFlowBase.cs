﻿namespace JServiceStack.Web
{
    public interface IWorkFlowBase
    {
        IWorkFlowBase AddValidator<TValidator>() where TValidator : IValidatorBase;
        IWorkFlowBase AddExecutor<TExecutor>() where TExecutor : IExecutorBase;
    }
}