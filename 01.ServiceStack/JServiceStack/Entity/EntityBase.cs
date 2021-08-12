using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JServiceStack.Entity
{
    public class EntityBase
    {
        [Key]
        [NotNull]
        public long Id { get; set; }
        [NotNull]
        public long CreationId { get; set; }
        [NotNull]
        public DateTime CreationDate { get; set; }
        public long ModificationId { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}