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
    public partial class AssistantRole : IRSAssistantRole
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
            return iRSUnitOfWork.CourseRepository.GetAll().Select(x => x.ToDomain().ToTransfertObject()).ToList();
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
}
