using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces.Repositories
{
    public interface IComponentTypeRepository : IRepository<ComponentTypeTO, int>
    {
        List<ComponentTypeTO> GetComponentTypesByRoom(RoomTO Room);
    }
}
