using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugDetail
    {
        public int BugId { get; set; }
        public string BugName { get; set; }
        public string BugDescription { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedTo { get; set; }
        public Stage Status { get; set; }
        public bool ActiveProblem { get; set; }
        public Priority Priority { get; set; }
        [Display(Name="Identified")]
        public DateTimeOffset IdentifiedUtc { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
