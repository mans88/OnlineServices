using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.RegistrationServices.TransferObject { 
    public class UserTO
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public bool IsActivated { get; set; }
        public ICollection<SessionTO> Sessions { get; set; }
        public UserRole Role { get; set; }
    }
}
