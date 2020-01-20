using Microsoft.EntityFrameworkCore;
using RegistrationServices.DataLayer.Entities;

namespace RegistrationServices.DataLayer
{
    public class RegistrationServicesContext : DbContext
    {
        public RegistrationServicesContext()
        {

        }

        public RegistrationServicesContext(DbContextOptions<RegistrationServicesContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null) throw new System.ArgumentNullException(nameof(optionsBuilder));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RegistrationServicesDB;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
                throw new System.ArgumentNullException(nameof(modelBuilder));

        }

        public DbSet<CourseEF> Courses { get; set; }
        public DbSet<SessionEF> Sessions { get; set; }
        public DbSet<UserEF> Users { get; set; }
        public DbSet<UserSessionEF> UserSessions { get; set; }
       // public DbSet<ProgramEF> Programs { get; set; }
    }
}
