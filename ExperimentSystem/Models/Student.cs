using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExperimentSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Matric No")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MatricNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Thesis Title")]
        [Required]
        public string ThesisTitle { get; set; }

        [Display(Name = "Group")]
        [Required]
        public string ClassGroup { get; set; }

        [Display(Name = "Semester Year")]
        [Required]
        public string BatchYear { get; set; }

        [Required]
        public string Faculty { get; set; }

        // List of Supervisor supervising students
        public virtual ICollection<Supervisor> Supervisors { get; set; }
    }
}