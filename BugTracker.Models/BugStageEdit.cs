using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugStageEdit
    {
        public int BugId { get; set; }
        public Stage Status { get; set; }
        public bool ActiveProblem { get; set; }
        public Priority Priority { get; set; }
    }
}
