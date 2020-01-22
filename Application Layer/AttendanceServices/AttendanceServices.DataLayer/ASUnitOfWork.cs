
using AttendanceServices.BusinessLayer.UseCases;
using AttendanceServices.DataLayer.Repositories;

using System;

namespace AttendanceServices.DataLayer
{
    public class ASUnitOfWork : IUnitOfWork
    {
        private AttendanceContext attendanceContext;

        public ASUnitOfWork(AttendanceContext contextIoC)
        {

            attendanceContext = contextIoC ?? throw new ArgumentNullException(nameof(contextIoC));
        }

        private IPresenceRepository presenceRepo;

        public IPresenceRepository PresenceRepository
        {
            get
            {
                presenceRepo ??= new PresenceRepository(attendanceContext) ?? throw new Exception(nameof(PresenceRepository));

                return presenceRepo;
            }
            private set
            {
                presenceRepo = value;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    attendanceContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return attendanceContext.SaveChanges();
        }
    }
}
