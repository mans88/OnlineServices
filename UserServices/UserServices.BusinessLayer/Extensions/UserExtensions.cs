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
                var UserDomain = new User
                {
                    Id = userTo.Id,
                    Name = userTo.Name,
                    Email = userTo.Email,
                    Company = userTo.Company,
                    IsActivated = userTo.IsActivated,
                    Role = userTo.Role,
                };

                UserDomain.IsValid();

                return UserDomain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static UserTO ToTransfertObject(this User user)
        {
            return new UserTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Company = user.Company,
                IsActivated = user.IsActivated,

                Role = user.Role,
            };
        }
    }
}