using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class IncidentExtensions
    {
        public static Incident ToDomain(this IncidentTO IncidentTO)
        {
            return new Incident
            {
                Id = IncidentTO.Id,
                Component = IncidentTO.Component.ToDomain(),
                Issue = IncidentTO.Issue.ToDomain(),
                Comment = IncidentTO.Comment,
                Status = IncidentTO.Status,
                SubmitDate = IncidentTO.SubmitDate
               
            };
        }

        public static IncidentTO ToTransfertObject(this Incident Incident)
        {
            return new IncidentTO
            {
                Id = Incident.Id,
                Component = Incident.Component.ToTransfertObject(),
                Issue = Incident.Issue.ToTransfertObject(),
                Comment = Incident.Comment,
                Status = Incident.Status,
                SubmitDate = Incident.SubmitDate
            };
        }
    }
}
