using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryJobsEF.Models
{
    public class Job
    {
        public Guid Id { get; set; }

        public Guid IdCategory { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifedDate { get; set; }

        public virtual Category Category { get; set; }

    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
