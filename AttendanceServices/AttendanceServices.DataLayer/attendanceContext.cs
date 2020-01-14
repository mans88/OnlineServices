using AttendanceServices.BusinessLayer.UseCases;
using Microsoft.EntityFrameworkCore;

namespace AttendanceService.DataLayer
{
    public class AttendanceContext : DbContext
    {
        public DbSet<AttendeePresentEF> AttendeePresents { get; set; }
    }
}