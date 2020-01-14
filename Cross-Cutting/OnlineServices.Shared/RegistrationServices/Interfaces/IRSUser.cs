namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSUser
    {
        int GetID();

        bool Login();

        void Logout();
    }
}