using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugEdit
    {
        public int BugId { get; set; }

        public string BugName { get; set; }
        public string BugDescription { get; set; }
        public DateTimeOffset IdentifiedUtc { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedTo { get; set; }
        public Stage Status { get; set; }
        public bool ActiveProblem { get; set; }
        public Priority Priority { get; set; }

        public DateTimeOffset ExpectedResolutionUTC { get; set; }
        public DateTimeOffset? ActualResolutionUTC { get; set; }
        public string ResolutionSummary { get; set; }
    }
}
