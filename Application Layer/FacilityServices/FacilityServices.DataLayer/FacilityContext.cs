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
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
                throw new System.ArgumentNullException(nameof(modelBuilder));

            modelBuilder.Entity<RoomComponentEF>().HasKey(si => new { si.RoomId, si.ComponentTypeId });

            modelBuilder.Entity<RoomComponentEF>()
                .HasOne<RoomEF>(RoomsComponentsEF => RoomsComponentsEF.Room)
                .WithMany(RoomEF => RoomEF.RoomComponents)
                .HasForeignKey(RoomComponentEF => RoomComponentEF.RoomId);

            modelBuilder.Entity<RoomComponentEF>()
                .HasOne<ComponentTypeEF>(RoomComponentEF => RoomComponentEF.ComponentType)
                .WithMany(ComponentEF => ComponentEF.RoomComponents)
                .HasForeignKey(RoomsWithComponent => RoomsWithComponent.ComponentTypeId);
        }

        public DbSet<IncidentEF> Incidents { get; set; }
        public DbSet<IssueEF> Issues { get; set; }
        public DbSet<RoomEF> Rooms { get; set; }
        public DbSet<FloorEF> Floors { get; set; }
        public DbSet<ComponentTypeEF> ComponentTypes { get; set; }
        public DbSet<CommentEF> Comments { get; set; }
        public DbSet<RoomComponentEF> RoomComponents { get; set; }
    }
}
