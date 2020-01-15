using FacilityServices.DataLayer.Repositories;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.DataLayer
{
    public class FSUnitOfWork : IFSUnitOfWork

    {
        private readonly FacilityContext facilityContext;

        public FSUnitOfWork(FacilityContext ContextIoC)
        {
            this.facilityContext = ContextIoC ?? throw new ArgumentNullException(nameof(ContextIoC));
        }

        private IComponentTypeRepository componentTypeRepository;
        public IComponentTypeRepository ComponentTypeRepository
            => componentTypeRepository ??= new ComponentTypeRepository(facilityContext);

        private ICommentRepository commentRepository;
        public ICommentRepository CommentRepository
            => commentRepository ??= new CommentRepository(facilityContext);

        private IFloorRepository floorRepository;
        public IFloorRepository FloorRepository
            => floorRepository ??= new FloorRepository(facilityContext);

        private IIssueRepository issueRepository;
        public IIssueRepository IssueRepository
             =>issueRepository ??= new IssueRepository(facilityContext);

        private IRoomRepository roomRepository;
        public IRoomRepository RoomRepository
            => roomRepository ??= new RoomRepository(facilityContext);

        private IIncidentRepository incidentRepository;
        public IIncidentRepository IncidentRepository
            => incidentRepository ??= new IncidentRepository(facilityContext);
        
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                   facilityContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            facilityContext.SaveChanges();
        }
    }
}
