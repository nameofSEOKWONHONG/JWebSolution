namespace JServiceStack.Web
{
    /// <summary>
    /// workflow json을 read하기 위한 Entity
    /// </summary>
    public class WorkflowEntity
    {
        public string[] Validators { get; set; }

        public ExecutorEntity[] Executors { get; set; }
    }

    /// <summary>
    /// Executor의 구분
    /// </summary>
    public class ExecutorEntity
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