using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public bool CreateIncident(IncidentTO incidentTO)
        {
            if (incidentTO is null)
                throw new ArgumentNullException();

            if (incidentTO.Id != 0)
                throw new Exception("Existing incident");

            // Todo : add incidentTO.Verify() or something similar

            try
            {
                var incident = unitOfWork.IncidentRepository.Add(incidentTO);
                if (incident.Id != 0)
                    return true;
            }
            catch (Exception ex)
            {
                // Todo check unique constraints, check if room + componenttype exists, etc.
            }
            return true;
        }
    }
}
