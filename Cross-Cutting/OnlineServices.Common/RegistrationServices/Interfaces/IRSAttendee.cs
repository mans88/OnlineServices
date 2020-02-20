namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSAttendee
    {
        int GetID();

        bool Login();

        void Logout();
    }
}