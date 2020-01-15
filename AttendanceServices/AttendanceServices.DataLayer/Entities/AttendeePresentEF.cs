using OnlineServices.Common.DataAccessHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceServices.DataLayer.Entities
{
    [Table("AttendeePresent")]
    public class AttendeePresentEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int AttendeeID { get; set; }
        public int SessionID { get; set; }
        public DateTime Presence { get; set; }
    }
}