using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExperimentSystem.Models
{
    public class Supervisor
    {
        [Key]
        public int StaffId { get; set; }

        public string Name { get; set; }

        public string Faculty { get; set; }

        // List of students under supervision
        public virtual ICollection<Student> Students { get; set; }
    }
}