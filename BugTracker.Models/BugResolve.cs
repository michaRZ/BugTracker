using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugResolve
    {
        public int BugId { get; set; }
        public string BugDescription { get; set; }
        public DateTimeOffset? ActualResolutionUTC { get; set; }
        public string ResolutionSummary { get; set; }
    }
}
