using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayer.Extensions
{
    public static class CourseExtensions
    {
        public static Course ToDomain(this CourseTO courseTO)
        {
            if (courseTO is null)
                throw new ArgumentNullException(nameof(courseTO));

            return new Course
            {
                Id = courseTO.Id,
                Name = courseTO.Name,
            };
        }

        public  static CourseTO ToTransferObject(this Course course)
        {
            if (course is null)
                throw new ArgumentNullException(nameof(course));
            return new CourseTO
            {
                Id = course.Id,
                Name = course.Name,
            };
        }
    }
}
