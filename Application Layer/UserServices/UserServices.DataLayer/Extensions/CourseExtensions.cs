using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationServices.DataLayer.Extensions
{
    public static class CourseExtensions
    {
        public static CourseTO ToTransfertObject(this CourseEF course)
        {
            return new CourseTO()
            {
                Id = course.Id,
                Name = course.Name
            };
        }

        public static CourseEF ToEF(this CourseTO course)
        {
            return new CourseEF()
            {
                Id = course.Id,
                Name = course.Name
            };
        }
    }
}