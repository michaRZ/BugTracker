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

        [Required(ErrorMessage = "Please enter a Start Date for the project")]
        public DateTimeOffset StartDate { get; set; }
        [Required(ErrorMessage = "Please enter a projected End Date for the project")]
        public DateTimeOffset DateEndProjected { get; set; }
    }
}
