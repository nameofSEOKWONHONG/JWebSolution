using System.Collections.Generic;

namespace JServiceStack.Web
{
    public class JDataContext
    {
        public Dictionary<string, object> Request { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Response { get; set; } = new Dictionary<string, object>();
    }
}