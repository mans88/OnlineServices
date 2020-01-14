using AttendanceServices.BusinessLayer.UseCases;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using AttendanceService.DataLayer;

namespace AttendanceService.DataLayer.Repositories
{
    public class PresenceRepository : IPresenceRepository
    {
        private AttendanceContext attendanceContext;

        public PresenceRepository(AttendanceContext ContextInjectedContextIoC)
        {
            this.attendanceContext = ContextInjectedContextIoC;
        }

        public AttendeePresenceTO Add(AttendeePresenceTO Entity)
        {
            //var to = 
            attendanceContext.AttendeePresents.Add(null);
            //.Entity.ToTransfertObject();
            
            return null; //to;
        }
        public AttendeePresenceTO SuperAddMethod(AttendeePresenceTO Entity)
        {
            //var to = 
            attendanceContext.AttendeePresents.Add(null);
            //.Entity.ToTransfertObject();

            return null; //to;
        }

    }
}
