using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExperimentSystem.Models
{
    public class ExperimentContext : DbContext
    {
        public ExperimentContext() : base("name=ExperimentContext")
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
    }
}