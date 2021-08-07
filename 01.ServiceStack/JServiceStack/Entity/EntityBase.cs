using System;

namespace JServiceStack.Entity
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}