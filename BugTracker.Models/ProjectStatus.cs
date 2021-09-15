using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ProjectStatus
    {
        // Model for archiving a project, with nullable completion date
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? DateEndActual { get; set; }
    }
}
