using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RegistrationServices.DataLayer.Entities
{
    [Table("UserSession")]
    public class UserSessionEF : IEquatable<UserSessionEF>
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public UserEF User { get; set; }

        [ForeignKey("SessionId")]
        public int SessionId { get; set; }

        public SessionEF Session { get; set; }

        public bool Equals([AllowNull] UserSessionEF other)
        {
            throw new NotImplementedException();
        }
    }
}