using OnlineServices.Common.FacilityServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSAttendeeRole
    {
        public bool CreateIncident(IncidentTO incidentTO);
        public List<IncidentTO> GetUserIncidents(int userId);
        public List<IssueTO> GetIssues();
        public List<FloorTO> GetFloors();
        public List<RoomTO> GetRooms();
        public List<ComponentTypeTO> GetComponentTypes();
    }
}
