using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemoEF.Models;

namespace WebApplicationDemoEF.StudentDBContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> context ) : base(context)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
