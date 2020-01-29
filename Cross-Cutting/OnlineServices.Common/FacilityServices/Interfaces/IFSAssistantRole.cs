using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSAssistantRole : IFSAttendeeRole
    {
        List<IncidentTO> GetIncidents();
        CommentTO AddComment(CommentTO comment);
        ComponentTypeTO AddComponentType(ComponentTypeTO componentTypeToAdd);
        ComponentTypeTO UpdateComponentType(ComponentTypeTO componentTypeToUpdate);
        bool RemoveComponentType(int componentTypeId);
        FloorTO AddFloor(FloorTO floorToAdd);
        FloorTO UpdateFloor(FloorTO floorToUpdate);
        bool RemoveFloor(int floorId);
        RoomTO AddRoom(RoomTO roomToAdd);
        RoomTO UpdateRoom(RoomTO roomToUpdate);
        bool RemoveRoom(int roomId);
        IssueTO AddIssue(IssueTO issueToAdd);
        IssueTO UpdateIssue(IssueTO issueToUpdate);
        bool RemoveIssue(int issueId);
        IncidentTO ChangeIncidentStatus(IncidentStatus statusToSubmit, int incidentId);
    }
}