using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FundamentosEntityFrameWork.Models
{
      public class Job
      {
            //[Key]
            public Guid Id { get; set; }

            //[ForeignKey("IdCategory")]
            public Guid IdCategory { get; set; }

            //[Required]
            public string Name { get; set; }

            //[MaxLength(1000)]
            public string Description { get; set; }

            //[Required]
            public Priority Priority { get; set; }

            //[Required]
            public DateTime CreatedDate { get; set; }

            public virtual Category Category { get; set; }

      }

      public enum Priority
      {
            Low,
            Medium,
            High
      }
}