using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.Extensions;
using RegistrationServices.BusinessLayer.Extensions;
using OnlineServices.Common.RegistrationServices.Interfaces;
using System.Linq;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.Exceptions;

namespace RegistrationServices.BusinessLayer.UseCase.Assistant
{
    public partial class AssistantRole : IRSAssistantRoleUser
    {
        public bool AddUser(UserTO userTO)
        {
            if (userTO is null)
                throw new LoggedException(new ArgumentNullException(nameof(userTO)));

            if (userTO.Id != 0)
                throw new Exception("Existing user");

            userTO.Name.IsNullOrWhiteSpace("Missing User Name.");

            try
            {
                iRSUnitOfWork.UserRepository.Add(userTO.ToDomain().ToTransfertObject());

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
                throw new ArgumentNullException((nameof(userTO)));

            if (userTO.Id == 0)
                throw new Exception("User does not exist");

            userTO.Name.IsNullOrWhiteSpace("Missing User Name");

            try
            {
                iRSUnitOfWork.UserRepository.Update(userTO.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveUser(UserTO userTO)
        {
            if (userTO is null)
                throw new ArgumentNullException(nameof(userTO));

            if (userTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.UserRepository.Remove(userTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<UserTO> GetUsers()
        {
            return iRSUnitOfWork.UserRepository.GetAll().Select(x => x.ToDomain().ToTransfertObject()).ToList();
        }

        public UserTO GetUserById(int id)
        {
            return iRSUnitOfWork.UserRepository.GetById(id);
        }
    }
}
