using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundamentosEntityFrameWork.Models
{
      public class Category
      {
            //[Key]
            public Guid Id { get; set; }
            
            //[Required]
            public string Name { get; set; }

            //[MaxLength(1000)]
            public string Description { get; set; }

            public DateTime CreatedDate { get; set; }
            
            public virtual ICollection<Job> Jobs { get; set; }
      }
}