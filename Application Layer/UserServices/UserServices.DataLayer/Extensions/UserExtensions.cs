using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;

namespace RegistrationServices.DataLayer.Extensions
{
    public static class UserExtensions
    {
        public static UserTO ToTransfertObject(this UserEF user)
        {
            return new UserTO
            {
                Id = user.Id,
                Name = user.Name,
                Company = user.Company,
                Email = user.Email,
                Role = user.Role,
                IsActivated = user.IsActivated,
            };
        }

        public static UserEF ToEF(this UserTO user)
        {
            return new UserEF
            {
                Id = user.Id,
                Name = user.Name,
                Company = user.Company,
                Email = user.Email,
                Role = user.Role,
                IsActivated = user.IsActivated,
            };
        }

        public static UserEF UpdateFromDetached(this UserEF AttachedEF, UserEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException();

            if (DetachedEF is null)
                throw new NullReferenceException();

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update userEF entity because it' not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Role = DetachedEF.Role;
                AttachedEF.Name = DetachedEF.Name;
                AttachedEF.Email = DetachedEF.Email;
                AttachedEF.Company = DetachedEF.Company;
            }

            return AttachedEF;
        }
    }
}