using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class IncidentExtensions
    {
        public static IncidentTO ToTranfertsObject(this IncidentEF Incident)
        {
            if (Incident is null)
                throw new ArgumentNullException(nameof(Incident));

            return new IncidentTO
            {
                Id = Incident.Id,
                Component = Incident.Component.ToTranfertsObject(),
                Issue = Incident.Issue.ToTranfertsObject(),
                Comment = Incident.Comment,
                Status = Incident.Status,
                SubmitDate = Incident.SubmitDate
            };
        }

        public static IncidentEF ToEF(this IncidentTO Incident)
        {
            if (Incident is null)
                throw new ArgumentNullException(nameof(Incident));

            return new IncidentEF
            {
                Id = Incident.Id,
                Component = Incident.Component.ToEF(),
                Issue = Incident.Issue.ToEF(),
                Comment = Incident.Comment,
                Status = Incident.Status,
                SubmitDate = Incident.SubmitDate
            };
        }
    }
}
