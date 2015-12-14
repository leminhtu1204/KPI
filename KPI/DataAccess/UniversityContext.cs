using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Entity;

namespace DataAccess
{
    public class UniversityContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public UniversityContext()
            : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // avoid plural name when generate table like students, enrollments
        }
    }
}
