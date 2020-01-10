using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineServices.Common.RegistrationServices.TransferObject;


namespace RegistrationServices.BusinessLayer.Extensions
{
    public static class UserExtensions
    {
        public static User ToDomain(this UserTO userTo)
        {
            try
            {
                var session = userTo.Sessions?.Select(x => x.ToDomain()).ToList();
                var UserDomain = new User
                {
                    Id = userTo.Id,
                    Name = userTo.Name,
                    Email = userTo.Email,
                    Company = userTo.Company,
                    IsActivated = userTo.IsActivated,
                    Role = userTo.Role,
                    Sessions = session
                };

                UserDomain.IsValid();

                return UserDomain;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static UserTO ToTransferObject(this User user)
        {
            return new UserTO 
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email, 
                Company = user.Company, 
                IsActivated = user.IsActivated,
                Sessions = user.Sessions?.Select(x=> x.ToTransferObject()).ToList(),
                Role = user.Role,
            };
        }
    }
}
