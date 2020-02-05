using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationServices.DataLayer.Repositories
{
    public class CourseRepository : IRSCourseRepository
    {
        private readonly RegistrationContext registrationContext;

        public CourseRepository(RegistrationContext registrationContext)
        {
            this.registrationContext = registrationContext;
        }

        public CourseTO Add(CourseTO Entity)
        {
            if (Entity.Id != 0)
            {
                return Entity;
            }

            return registrationContext.Courses.Add(Entity.ToEF()).Entity.ToTransfertObject();
        }

        public IEnumerable<CourseTO> GetAll()
         => registrationContext.Courses
            .AsNoTracking()
            .Select(x => x.ToTransfertObject())
            .ToList();

        public CourseTO GetById(int Id)
           => registrationContext.Courses.AsNoTracking()
                                   .Include(x => x.Name)
                                   .FirstOrDefault(x => x.Id == Id)
                                   .ToTransfertObject();

        public bool Remove(CourseTO entity)
        {
            try
            {
                registrationContext.Courses.Remove(entity.ToEF());
                return true;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public bool Remove(int Id)
        {
            return Remove(GetById(Id));
        }

        public CourseTO Update(CourseTO Entity)
        {
            if (!registrationContext.Courses.Any(x => x.Id == Entity.Id))
            {
                throw new Exception($"Can't find user to update. UserRepository");
            }
            var attachedUser = registrationContext.Courses.FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedUser != default)
            {
                attachedUser.UpdateFromDetached(Entity.ToEF());
            }

            return registrationContext.Courses.Update(attachedUser).Entity.ToTransfertObject();
        }
    }
}