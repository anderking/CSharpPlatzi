using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryJobsBlazor.Models
{
    public class Category : EntityBase
    {
        public string Description { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
