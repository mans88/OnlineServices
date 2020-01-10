using OnlineServices.Common.Exceptions;
using OnlineServices.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.Extensions;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayer.UseCase
{
    public class Assistant
    {
        private readonly IRSUnitOfWork iRSUnitOfWork;

        public Assistant(IRSUnitOfWork iRSUnitOfWork) //: base (iRSUnitOfWork)
        {
            this.iRSUnitOfWork = iRSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iRSUnitOfWork));
        }

        public Assistant()
        {
        }

        /*
         * 
         public AssistantRole(IMSUnitOfWork iMSUnitOfWork) : base(iMSUnitOfWork)
        {
            this.iMSUnitOfWork = iMSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iMSUnitOfWork));
        }
         * 
         * */
        public bool AddUser(UserTO userTO)
        {
            if (userTO is null)
                throw new LoggedException(new ArgumentNullException(nameof(userTO)));

            if (userTO.Id != 0)
                throw new Exception("Existing user");

            userTO.Name.IsNullOrWhiteSpace("Missing User Name.");

            try
            {
                userTO.ToDomain();
                iRSUnitOfWork.UserRepository.Add(userTO);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUser(UserTO userTO)
        {
            if (userTO is null)
                throw new LoggedException(new AccessViolationException(nameof(userTO)));

            if (userTO.Id == 0)
                throw new Exception("User does not exist");

            userTO.Name.IsNullOrWhiteSpace("Missing User Name");

            try
            {
                iRSUnitOfWork.UserRepository.Update(userTO);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveUser(UserTO userTO)
        {
            if(userTO is null)
                throw new LoggedException(new AccessViolationException(nameof(userTO)));

            if (userTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.UserRepository.Remove(userTO);
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
