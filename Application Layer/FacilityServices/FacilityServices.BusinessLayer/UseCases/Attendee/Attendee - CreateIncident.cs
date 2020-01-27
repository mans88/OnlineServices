using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public bool CreateIncident(IncidentTO incidentTO)
        {
            if (incidentTO is null)
                throw new ArgumentNullException(nameof(incidentTO));

            if (incidentTO.Id != 0)
                throw new LoggedException("The incident ID has to be 0 when adding a new incident.");

            // Todo : add incidentTO.Verify() or something similar

            if (incidentTO.Issue is null)
                throw new LoggedException("The incident has to reference an existing issue.");

            if (incidentTO.Room is null)
                throw new LoggedException("The incident has to reference an existing room.");

            if (incidentTO.Status != IncidentStatus.Waiting)
                throw new LoggedException("The incident status has to be IncidentStatus.Waiting when creating a new incident.");

            // Todo check unique constraints, check if room + componenttype exists, etc.
            var incident = unitOfWork.IncidentRepository.Add(incidentTO);
            return incident.Id != 0;
        }
    }
}
