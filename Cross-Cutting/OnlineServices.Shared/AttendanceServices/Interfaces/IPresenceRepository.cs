using OnlineServices.Common.AttendanceServices.TransfertObjects;

namespace AttendanceServices.BusinessLayer.UseCases
{
    public interface IPresenceRepository //:IRepositoryTemp<AttendeePresenceTO,int>
    {
        AttendeePresenceTO Add(AttendeePresenceTO Entity);
    }
}