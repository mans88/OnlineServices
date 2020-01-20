using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RegistrationServices.DataLayer.Entities
{
    [Table("UserSession")]
    public class UserSessionEF
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public UserEF User { get; set; }

        [ForeignKey("SessionId")]
        public int SessionId { get; set; }

        public SessionEF Session { get; set; }
    }
}