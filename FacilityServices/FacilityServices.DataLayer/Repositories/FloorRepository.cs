using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    internal class FloorRepository : IFloorRepository
    {
        private FacilityContext facilityContext;

        public FloorRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public FloorTO Add(FloorTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FloorTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public FloorTO GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(FloorTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public FloorTO Update(FloorTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}