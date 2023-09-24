using Microsoft.EntityFrameworkCore;

namespace SMT_ITIWithDb.Models
{
    public class EmployeeContext:DbContext
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITI_G4;Trusted_Connection=True;TrustServerCertificate=True");
        }
      public DbSet<Employee> employees { get; set; }
       public DbSet<Project> Projects { get; set; }
     public   DbSet<Office> Offices { get; set; }
        public DbSet<Emp_Pro> Emp_Pros { get; set; }
    }
}