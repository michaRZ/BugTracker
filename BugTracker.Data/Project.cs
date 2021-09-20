using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        
        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset DateEndProjected { get; set; }
        public DateTimeOffset? DateEndActual { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }

        public virtual ICollection<Person> People { get; set; }

    }
}
