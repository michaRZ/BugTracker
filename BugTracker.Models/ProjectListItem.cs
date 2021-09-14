using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ProjectListItem
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "Projected End Date")]
        public DateTimeOffset DateEndProjected { get; set; }

    }
}
