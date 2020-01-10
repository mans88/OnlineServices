using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    internal class RoomRepository : IRoomRepository
    {
        private FacilityContext facilityContext;

        public RoomRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public RoomTO Add(RoomTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RoomTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public RoomTO GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<RoomTO> GetRoomsByFloors(FloorTO Floor)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(RoomTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public RoomTO Update(RoomTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}