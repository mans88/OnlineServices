using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSAssistantRole : IFSAttendeeRole
    {
        public bool EditComment(string comment, int incidentId);
        public bool AddComponent(ComponentTO componentToAdd);
        public bool AddFloor(FloorTO floorToAdd);
        public bool AddRoom(RoomTO roomToAdd);
        public bool AddIssue(IssueTO issueToAdd);
        public bool ChangeIncidentStatus(IncidentStatus statusToSubmit, int incidentId);

    }
}
