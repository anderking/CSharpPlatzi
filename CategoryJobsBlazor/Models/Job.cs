﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryJobsBlazor.Models
{
    public class Job: EntityBase
    {
        public string IdCategory { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public virtual Category Category { get; set; }

    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
