using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Models;

namespace TelerikAcademy.Context
{
    public class AcademyContext : DbContext
    {
        public AcademyContext()
            : base("TelerikAcademyEntities")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
