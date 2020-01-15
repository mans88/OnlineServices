using OnlineServices.Common.FacilityServices.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer
{
    public class Incident
    {
        public int Id { get; set; }
        public Component Component { get; set; }
        public Issue Issue { get; set; }
        public string Comment { get; set; }
        public DateTime SubmitDate { get; set; }
        public IncidentStatus Status { get; set; }

    }
}
