using System.ComponentModel.DataAnnotations.Schema;
using JServiceStack.Entity;

namespace Entity
{
    [Table("ACCOUNT")]
    public class ACCOUNT : EntityBase
    {
        public string NAME { get; set; }
        public string TEL { get; set; }
        public string EMAIL { get; set; }
    }
}