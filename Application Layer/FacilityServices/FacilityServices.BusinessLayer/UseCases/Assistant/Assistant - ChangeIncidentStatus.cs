using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public IncidentTO ChangeIncidentStatus(IncidentStatus statusToSubmit, int incidentId)
        {
            var incident = unitOfWork.IncidentRepository.GetById(incidentId);
            incident.Status = statusToSubmit;
            var updatedIncident = unitOfWork.IncidentRepository.Update(incident);

            return updatedIncident;
        }
    }
}