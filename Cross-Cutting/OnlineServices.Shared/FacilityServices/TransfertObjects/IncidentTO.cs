using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.FacilityServices.Enumerations;
using System;

namespace OnlineServices.Common.FacilityServices.TransfertObjects
{
    public class IncidentTO : IEntity<int>
    {
        public int Id { get; set; }
        public ComponentTO Component { get; set; }
        public IssueTO Issue { get; set; }
        public string Comment { get; set; }
        public DateTime SubmitDate { get; set; }
        public IncidentStatus Status { get; set; }
    }

}
