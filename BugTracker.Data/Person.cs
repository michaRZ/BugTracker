using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public enum Role {Intern, JuniorDeveloper, SoftwareDeveloper, TechnicalLead, SoftwareArchitect}
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Role Role { get; set; }

        [ForeignKey(nameof(Project))]
        [Display(Name = "Assigned Project")]
        public int? ProjectId { get; set; } 
        public bool IsActive { get; set; }
    }
}
