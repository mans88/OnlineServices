using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    internal class IncidentRepository : IIncidentRepository
    {
        private FacilityContext facilityContext;

        public IncidentRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public IncidentTO Add(IncidentTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IncidentTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IncidentTO GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<IncidentTO> GetIncidentsByUserId(int UserId)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IncidentTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IncidentTO Update(IncidentTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}