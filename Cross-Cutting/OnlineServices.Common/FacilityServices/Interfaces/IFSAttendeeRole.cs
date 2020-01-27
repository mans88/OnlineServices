using OnlineServices.Common.FacilityServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSAttendeeRole
    {
        public bool CreateIncident(IncidentTO incidentTO);
        public List<IncidentTO> GetUserIncidents(int userId);
        public List<IssueTO> GetIssuesByComponentType(int componentTypeId);
        public List<FloorTO> GetFloors();
        public List<RoomTO> GetRoomsByFloor(int floorId);
        public List<ComponentTypeTO> GetComponentTypesByRoom(int roomId);
        public List<CommentTO> GetCommentsByIncident(int incidentId);
    }
}