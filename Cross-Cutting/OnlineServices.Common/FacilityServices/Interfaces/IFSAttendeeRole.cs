using OnlineServices.Common.FacilityServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSAttendeeRole
    {
        bool CreateIncident(IncidentTO incidentTO);
        List<IncidentTO> GetUserIncidents(int userId);
        List<IssueTO> GetIssuesByComponentType(int componentTypeId);
        List<FloorTO> GetFloors();
        List<RoomTO> GetRoomsByFloor(int floorId);
        List<ComponentTypeTO> GetComponentTypesByRoom(int roomId);
        List<CommentTO> GetCommentsByIncident(int incidentId);
    }
}