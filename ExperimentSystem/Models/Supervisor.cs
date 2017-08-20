using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExperimentSystem.Models
{
    public class Supervisor
    {
        public int Id { get; set; }

        [Display(Name = "Staff No")]
        public string StaffId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Faculty { get; set; }

        // List of students under supervision
        public virtual ICollection<Student> Students { get; set; }
    }
}