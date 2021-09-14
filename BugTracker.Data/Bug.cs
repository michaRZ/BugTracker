using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public enum Stage {New =1, Assign, Open, Fixed, Test, Verified, Closed, Reopen, Duplicate, Deferred, Rejected}
    public enum Priority {None, Low, Medium, High}
    public class Bug
    {
        [Key]
        public int BugId { get; set; }
        [Required]
        public string BugName { get; set; }
        [Required]
        public string BugDescription { get; set; }
        [Required]
        public DateTimeOffset IdentifiedUtc { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public int? AssignedTo { get; set; }
        public Stage Status { get; set; }
        public bool ActiveProblem { get; set; } = true;
        public Priority? Priority { get; set; }

        public DateTimeOffset ExpectedResolutionUTC { get; set; }
        public DateTimeOffset? ActualResolutionUTC { get; set; }
        public string ResolutionSummary { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        public string ModifiedBy { get; set; }
    }
}
