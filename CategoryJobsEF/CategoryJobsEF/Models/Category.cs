using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryJobsEF.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifedDate { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
