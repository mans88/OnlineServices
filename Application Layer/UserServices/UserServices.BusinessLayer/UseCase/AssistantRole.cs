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

namespace RegistrationServices.BusinessLayer.UseCase
{
    public partial class AssistantRole : IRSAssistantRoleUser
    {
        private readonly IRSUnitOfWork iRSUnitOfWork;

        public AssistantRole(IRSUnitOfWork iRSUnitOfWork)
        {
            this.iRSUnitOfWork = iRSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iRSUnitOfWork));
        }

        public AssistantRole()
        {

        }

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


    //===================================================================================================================================

    public partial class AssistantRole : IRSAssistantRoleCourse
    {
        public bool AddCourse(CourseTO courseTo)
        {
            if (courseTo is null)
            {
                throw new ArgumentNullException(nameof(courseTo));
            }
            if (courseTo.Id != 0)
            {
                throw new Exception("Existing Course");
            }

            courseTo.Name.IsNullOrWhiteSpace("Missing course name");

            try
            {
                iRSUnitOfWork.CourseRepository.Add(courseTo.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CourseTO GetCourseById(int id)
        {
            return iRSUnitOfWork.CourseRepository.GetById(id);
        }

        public List<CourseTO> GetCourses()
        {
            return iRSUnitOfWork.CourseRepository.GetAll().Select(x=>x.ToDomain().ToTransfertObject()).ToList();
        }

        public bool RemoveCourse(CourseTO courseTo)
        {
            if (courseTo is null)
            {
                throw new ArgumentNullException(nameof(courseTo));
            }

            if (courseTo.Id == 0)
            {
                throw new Exception("Course does not exist");
            }

            try
            {
                iRSUnitOfWork.CourseRepository.Remove(courseTo.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCourse(CourseTO courseTo)
        {
            if (courseTo is null)
            {
                throw new ArgumentNullException(nameof(courseTo));
            }
            if (courseTo.Id == 0)
            {
                throw new Exception("Course does not exist");
            }

            courseTo.Name.IsNullOrWhiteSpace("Missing Course Name");
            
            try
            {
                iRSUnitOfWork.CourseRepository.Update(courseTo.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    //===================================================================================================================================
    public partial class AssistantRole : IRSAssistantRoleSession
    {
        public bool AddSession(SessionTO sessionTO)
        {
            if (sessionTO is null)
                throw new ArgumentNullException(nameof(sessionTO));

            if (sessionTO.Id != 0)
                throw new Exception("Existing Session");

            try
            {
                iRSUnitOfWork.SessionRepository.Add(sessionTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateSession(SessionTO sessionTO)
        {
            if (sessionTO is null)
                throw new ArgumentNullException((nameof(sessionTO)));

            if (sessionTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.SessionRepository.Update(sessionTO.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveSession(SessionTO sessionTO)
        {
            if (sessionTO is null)
                throw new ArgumentNullException(nameof(sessionTO));

            if (sessionTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.SessionRepository.Remove(sessionTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<SessionTO> GetSessions()
        {
            return iRSUnitOfWork.SessionRepository.GetAll().Select(x => x.ToDomain().ToTransfertObject()).ToList();
        }

        public SessionTO GetSessionById(int id)
        {
            return iRSUnitOfWork.SessionRepository.GetById(id);
        }
    }

}
