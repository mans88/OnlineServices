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
            if (course is null)
                throw new NullReferenceException(nameof(course));
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

        public static CourseEF UpdateFromDetached(this CourseEF AttachedEF, CourseEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException();

            if (DetachedEF is null)
                throw new NullReferenceException();

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update courseEF entity because it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Id = DetachedEF.Id;
                AttachedEF.Name = DetachedEF.Name;
            }

            return AttachedEF;
        }
    }
}