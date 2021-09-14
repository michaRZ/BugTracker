using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugListItem
    {
        public int BugId { get; set; }
        public string BugName { get; set; }
        public DateTimeOffset IdentifiedUtc { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedTo { get; set; }
        public Stage Status { get; set; }
    }
}
