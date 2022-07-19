using System;
using System.ComponentModel.DataAnnotations;

namespace API_Core_DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
