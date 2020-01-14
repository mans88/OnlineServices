using AttendanceService.DataLayer.Repositories;
using AttendanceServices.BusinessLayer.UseCases;
using System;

namespace AttendanceService.DataLayer
{
    public class ASUnitOfWork: IDisposable
    {
        private AttendanceContext attendanceContext;

        public ASUnitOfWork(AttendanceContext contextIoC)
        {

            attendanceContext = contextIoC ?? throw new ArgumentNullException(nameof(contextIoC));
        }

        private IPresenceRepository presenceRepo;

        public IPresenceRepository PresenceRepository
        {
            get {
                presenceRepo ??= new PresenceRepository(attendanceContext) ?? throw new Exception(nameof(PresenceRepository));

                return presenceRepo;
            }
            private set {
                presenceRepo = value;
            }
        }

        public PresenceRepository Repo1 {get; set; } // = new PresenceRepository(attendanceContext);
        public PresenceRepository Repo2 { get; set; } //= new PresenceRepository(attendanceContext);

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

        public bool SaveChanges()
        {
            attendanceContext.SaveChanges();
            return true;
        }
    }
}
