using AttendanceServices.BusinessLayer.UseCases;
using AttendanceServices.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceServices.DataLayer
{
    public class AttendanceContext : DbContext
    {
        public DbSet<AttendeePresentEF> AttendeePresents { get; set; }
    }
}