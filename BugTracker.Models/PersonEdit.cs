using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class PersonEdit
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public int? ProjectId { get; set; }
        public bool IsActive { get; set; }
    }
}
