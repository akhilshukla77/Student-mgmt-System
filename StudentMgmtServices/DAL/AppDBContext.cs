using Microsoft.EntityFrameworkCore;
using StudentMgmtServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMgmtServices.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> StudentsList { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Enrollment> StudentEnrollments { get; set; }
        public DbSet<StudentServices> StudentServices { get; set; }
    }
}
