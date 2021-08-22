using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JServiceStack.Entity
{
    public class ENTITY_BASE
    {
        [Key] 
        public long ID { get; set; }
        [NotNull]
        public long WRITER_ID { get; set; }
        [NotNull]
        public DateTime WRITE_DTM { get; set; }
        public long UPDATOR_ID { get; set; }
        public DateTime? UPDATE_DTM { get; set; }
    }
}