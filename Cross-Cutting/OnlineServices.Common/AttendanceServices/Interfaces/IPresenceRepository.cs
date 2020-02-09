using OnlineServices.Common.AttendanceServices.TransfertObjects;

namespace OnlineServices.AttendanceServices.Interfaces
{
    public interface IPresenceRepository //:IRepositoryTemp<AttendeePresenceTO,int>
    {
        AttendeePresenceTO Add(AttendeePresenceTO Entity);
    }
}