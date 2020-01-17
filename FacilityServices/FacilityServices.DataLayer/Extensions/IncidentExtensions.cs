using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.DataLayer.Extensions
{
    public static class IncidentExtensions
    {
        public static IncidentTO ToTransfertObject(this IncidentEF Incident)
        {
            if (Incident is null)
                throw new ArgumentNullException(nameof(Incident));

            return new IncidentTO
            {
                Id = Incident.Id,
                Issue = Incident.Issue.ToTransfertObject(),
                Status = Incident.Status,
                SubmitDate = Incident.SubmitDate,
                Description = Incident.Description,
                UserId = Incident.UserId,
                Room = Incident.Room.ToTransfertObject(),
            };
        }

        public static IncidentEF ToEF(this IncidentTO Incident)
        {
            if (Incident is null)
                throw new ArgumentNullException(nameof(Incident));

            return new IncidentEF
            {
                Id = Incident.Id,
                Issue = Incident.Issue.ToEF(),
                Status = Incident.Status,
                SubmitDate = Incident.SubmitDate,
                Description = Incident.Description,
                UserId = Incident.UserId,
                Room = Incident.Room.ToEF()
            };
        }

        public static IncidentEF UpdateFromDetached(this IncidentEF AttachedEF, IncidentEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update IncidentF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Description = DetachedEF.Description;
                AttachedEF.Issue = DetachedEF.Issue;
                AttachedEF.Room = DetachedEF.Room;
                AttachedEF.Status = DetachedEF.Status;
                AttachedEF.SubmitDate = DetachedEF.SubmitDate;
                AttachedEF.UserId = DetachedEF.UserId;
            }

            return AttachedEF;
        }
    }
}
