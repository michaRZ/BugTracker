using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class PersonCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please Enter a valid name")]
        [MaxLength(200, ErrorMessage ="There are too many characters in this field")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter a valid email")]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field")]
        public string Email { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter a valid role")]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field")]
        public Role Role { get; set; }
    }
}
