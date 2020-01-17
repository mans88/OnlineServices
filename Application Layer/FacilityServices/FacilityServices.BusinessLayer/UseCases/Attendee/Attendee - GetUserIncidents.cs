using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public List<IncidentTO> GetUserIncidents(int userId)
        {
            if (userId <= 0)
                throw new Exception("Bad userId.");

            try
            {
                var incidents = unitOfWork.IncidentRepository.GetIncidentsByUserId(userId);
                return incidents;
            }
            catch (LoggedException)
            {
                // Todo check unique constraints, check if room + componenttype exists, etc.
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
