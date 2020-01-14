using OnlineServices.Common.FacilityServices.Interfaces.Repositories;

using System;

namespace OnlineServices.Common.FacilityServices.Interfaces
{
    public interface IFSUnitOfWork : IDisposable
    {
        IComponentTypeRepository ComponentTypeRepository { get; }
        ICommentRepository CommentRepository { get; }
        IFloorRepository FloorRepository { get; }
        IIssueRepository IssueRepository { get; }
        IRoomRepository RoomRepository { get; }
        IIncidentRepository IncidentRepository { get; }

        void Save();
    }
}
