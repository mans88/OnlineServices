using OnlineServices.Common.DataAccessHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityServices.DataLayer.Entities
{
    [Table("Comments")]
    public class CommentEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public IncidentEF Incident { get; set; }
        public string Message { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
