using OnlineServices.Common.Exceptions;
using OnlineServices.Common.SecurityServices.TransfertObjects;

namespace OnlineServices.Common.SecurityServices.Extensions
{
    public static class ServiceAuthorizationExtensions
    {
        private static bool IsValide(ServiceAuthorization serviceAuthorizationExtended)
        {
            if (serviceAuthorizationExtended is null)
                return false;

            return (true);
            //TODO (true) TO IMPLEMENTED TEST. Move to the class itself????!!! !!!!NecessaryDataException to throw!
        }
        public static bool IsWellFormed(this ServiceAuthorization serviceAuthorizationExtended, bool ThrowException = false)
        {
            return !ThrowException ? IsValide(serviceAuthorizationExtended) : serviceAuthorizationExtended.IsWellFormed("IsWellFormed(false) @ ServiceAuthorizationExtensions");

        }
        public static bool IsWellFormed(this ServiceAuthorization serviceAuthorizationExtended, string ExceptionMessage)
        {
            return IsValide(serviceAuthorizationExtended) ? true : throw new NecessaryDataException(ExceptionMessage);
        }
    }
}
