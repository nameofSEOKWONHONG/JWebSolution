using System.ComponentModel.DataAnnotations.Schema;
using JServiceStack.Entity;

namespace Entity
{
    [Table("ACCOUNT")]
    public class ACCOUNT : ENTITY_BASE
    {
        public string USER_ID { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string TEL { get; set; }
        public string EMAIL { get; set; }
    }
}