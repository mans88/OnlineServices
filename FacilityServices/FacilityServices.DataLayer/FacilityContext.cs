using FacilityServices.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FacilityServices.DataLayer
{
    public class FacilityContext : DbContext
    {
        public FacilityContext()
        {

        }
        public FacilityContext(DbContextOptions<FacilityContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
                throw new ArgumentNullException(nameof(optionsBuilder));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FacilityDB;Trusted_Connection=True;");
            }
        }

        public DbSet<IncidentEF> Incidents { get; set; }
        public DbSet<IssueEF> Issues { get; set; }
        public DbSet<ComponentEF> Components { get; set; }
        public DbSet<RoomEF> Rooms { get; set; }
        public DbSet<FloorEF> Floors { get; set; }
    }
}
