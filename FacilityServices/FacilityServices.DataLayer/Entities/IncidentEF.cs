using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.FacilityServices.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityServices.DataLayer.Entities
{
    [Table("Incidents")]
    public class IncidentEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public ComponentEF Component { get; set; }
        public IssueEF Issue { get; set; }
        public string Comment { get; set; }
        public DateTime SubmitDate { get; set; }
        public IncidentStatus Status { get; set; }
    }
}
