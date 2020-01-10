using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;

namespace RegistrationServices.DataLayer.Extensions
{
    public static class UserExtensions
    {
        public static UserTO ToTransferObject(this UserEF userEF)
        {
            throw new NotImplementedException();
        }

        //public static UserEF ToEF(this UserTO userTO)

        //public static UserEF UpdateFromDetached(this UserEF AttachedEF, UserEF DetachedEF)
    }
}