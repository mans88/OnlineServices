using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAttendeeRole
    {
        public List<CommentTO> GetCommentsByIncident(int incidentId)
        {
            if (incidentId <= 0)
            {
                throw new LoggedException($"Invalid incident ID (ID={incidentId})");
            }

            var comments = unitOfWork.CommentRepository.GetCommentsByIncident(incidentId);
            return comments;
        }
    }
}
