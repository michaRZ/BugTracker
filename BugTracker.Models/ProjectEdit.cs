using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ProjectEdit
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DateEndProjected { get; set; }
    }
}
