﻿namespace JServiceStack.Web
{
    public interface IExecutorBase
    {
        string Name { get; }
        void Execute(JDataContext context);
    }
}