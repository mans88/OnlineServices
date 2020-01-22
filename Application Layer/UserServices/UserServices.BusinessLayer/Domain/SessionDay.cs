using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationServices.BusinessLayer.Domain
{
    public class SessionDay : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public SessionPresenceType PresenceType { get; set; }
    }
}