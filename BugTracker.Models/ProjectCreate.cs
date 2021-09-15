using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ProjectCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Project Name must be at least two characters in length")]
        [MaxLength(100, ErrorMessage = "Project Name character limit exceeded")]
        public string ProjectName { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset DateEndProjected { get; set; }
    }
}
