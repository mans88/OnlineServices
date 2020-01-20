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

            modelBuilder.Entity<UserSessionEF>().HasKey(si => new { si.SessionId, si.UserId });

            modelBuilder.Entity<UserSessionEF>()
                .HasOne<SessionEF>(s => s.Session)
                .WithMany(s => s.UserSessions)
                .HasForeignKey(s => s.SessionId);

            modelBuilder.Entity<UserSessionEF>()
                .HasOne<UserEF>(u => u.User)
                .WithMany(u => u.UserSessions)
                .HasForeignKey(u => u.UserId);
        }

        public DbSet<CourseEF> Courses { get; set; }
        public DbSet<SessionEF> Sessions { get; set; }
        public DbSet<SessionDayEF> SessionDays { get; set; }
        public DbSet<UserEF> Users { get; set; }
        public DbSet<UserSessionEF> UserSessions { get; set; }
        // public DbSet<ProgramEF> Programs { get; set; }
    }
}