using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryJobsMVC.Models
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool State { get; set; }

        public bool StateDelete { get; set; }

        public bool StateModified { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public string CreatedUserName { get; set; }

        public string CreatedUserEmail { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedUserName { get; set; }

        public string ModifiedUserEmail { get; set; }
    }
}
