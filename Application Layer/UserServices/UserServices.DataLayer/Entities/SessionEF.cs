using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RegistrationServices.DataLayer.Entities
{
    [Table("Session")]
    public class SessionEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public CourseEF Course { get; set; }

        public List<SessionDayEF> Dates { get; set; }

        // REVIEW public List<SessionDayEF> Dates { get; set; }
        public virtual ICollection<UserSessionEF> UserSessions { get; set; }
    }
}