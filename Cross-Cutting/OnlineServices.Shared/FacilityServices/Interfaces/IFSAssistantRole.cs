using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSAssistantRole : IFSAttendeeRole
    {
        public List<IncidentTO> GetIncidents();
        public CommentTO AddComment(CommentTO comment);
        public ComponentTypeTO AddComponentType(ComponentTypeTO componentTypeToAdd);
        public FloorTO AddFloor(FloorTO floorToAdd);
        public FloorTO UpdateFloor(FloorTO floorToUpdate);
        public bool RemoveFloor(int floorId);
        public RoomTO AddRoom(RoomTO roomToAdd);
        public RoomTO UpdateRoom(RoomTO roomToUpdate);
        public bool RemoveRoom(int roomId);
        public IssueTO AddIssue(IssueTO issueToAdd);
        public IssueTO UpdateIssue(IssueTO issueToUpdate);
        public bool RemoveIssue(int issueId);
        public IncidentTO ChangeIncidentStatus(IncidentStatus statusToSubmit, int incidentId);
    }
}