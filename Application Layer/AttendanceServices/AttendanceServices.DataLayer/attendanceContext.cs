using AttendanceServices.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceServices.DataLayer
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext()
        {
        }

        public AttendanceContext(DbContextOptions<AttendanceContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
                throw new System.ArgumentNullException(nameof(optionsBuilder));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AttendanceDB;Trusted_Connection=True;");
            }
        }

        public DbSet<AttendeePresentEF> AttendeePresents { get; set; }
    }
}