using FacilityServices.BusinessLayer.Domain;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class IncidentExtensions
    {
        public static Incident ToDomain(this IncidentTO IncidentTO)
        {
            if (IncidentTO is null)
            {
                throw new NullIncidentException(nameof(IncidentTO));
            }

            return new Incident
            {
                Id = IncidentTO.Id,
                Issue = IncidentTO.Issue.ToDomain(),
                Status = IncidentTO.Status,
                SubmitDate = IncidentTO.SubmitDate,
                UserId = IncidentTO.UserId,
                Description = IncidentTO.Description,
                Room = IncidentTO.Room.ToDomain(),
            };
        }

        public static IncidentTO ToTransfertObject(this Incident Incident)
        {
            if (Incident is null)
            {
                throw new NullIncidentException(nameof(Incident));
            }

            return new IncidentTO
            {
                Id = Incident.Id,
                Issue = Incident.Issue.ToTransfertObject(),
                Status = Incident.Status,
                SubmitDate = Incident.SubmitDate,
                UserId = Incident.UserId,
                Description = Incident.Description,
                Room = Incident.Room.ToTransfertObject(),
            };
        }
    }
}
