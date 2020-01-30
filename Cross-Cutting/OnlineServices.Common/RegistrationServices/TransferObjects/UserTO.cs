using OnlineServices.Common.DataAccessHelpers;

using System.Collections.Generic;

namespace OnlineServices.Common.RegistrationServices.TransferObject
{
    public class UserTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } // Non Null
        public string Company { get; set; }
        public string Email { get; set; } // Non Null
        public bool IsActivated { get; set; } // Non Null
        public UserRole Role { get; set; } // Non Null
    }
}