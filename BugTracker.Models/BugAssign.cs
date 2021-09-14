using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugAssign
    {
        public int BugId { get; set; }
        public int AssignedTo { get; set; }
    }
}
