using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationServices.DataLayer.Entities
{
    public class SessionDayEF : IEntity<int>
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public SessionPresenceType PresenceType { get; set; }
    }
}