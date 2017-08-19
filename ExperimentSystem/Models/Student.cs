using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExperimentSystem.Models
{
    public class Student
    {
        [Key]
        public int MatricNumber { get; set; }

        public string Name { get; set; }
        public string ThesisTitle { get; set; }


        public string ClassGroup { get; set; }
        public string BatchYear { get; set; }
        public string Faculty { get; set; }

        // List of Supervisor supervising students
        public virtual ICollection<Supervisor> Supervisors { get; set; }
    }
}