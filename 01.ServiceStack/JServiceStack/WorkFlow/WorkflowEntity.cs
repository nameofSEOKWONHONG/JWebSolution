namespace JServiceStack.Workflow
{
    /// <summary>
    /// workflow json을 read하기 위한 Entity
    /// </summary>
    internal class WorkflowEntity
    {
        public string[] Validators { get; set; }

        public ExecutorEntity[] Executors { get; set; }
    }

    /// <summary>
    /// Executor의 구분
    /// </summary>
    internal class ExecutorEntity
    {
        /// <summary>
        /// 일반 Executor
        /// </summary>
        public string Executor { get; set; }

        /// <summary>
        /// Transaction을 위한 Executor
        /// </summary>
        public string[] Executors { get; set; }
    }
}