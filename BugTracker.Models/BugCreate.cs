using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BugCreate
    {
        [Required]
        public string BugName { get; set; }
        [Required]
        public string BugDescription { get; set; }
        [Required]
        public DateTimeOffset IdentifiedUtc { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public int? AssignedTo { get; set; }
        public Priority? Priority { get; set; }
    }
}
