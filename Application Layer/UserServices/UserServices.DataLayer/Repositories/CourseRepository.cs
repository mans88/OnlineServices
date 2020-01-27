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
    class CourseRepository : IRSCourseRepository
    {
        private readonly RegistrationServicesContext rsContext;

        public CourseRepository(RegistrationServicesContext Context)
        {
            rsContext = Context ?? throw new ArgumentNullException($"{nameof(Context)} in CourseRepository");
        }
        public CourseTO Add(CourseTO Entity)
        {
            return rsContext.Add(Entity.ToEF()).Entity.ToTransfertObject();
        }

        public IEnumerable<CourseTO> GetAll()
        => rsContext.Courses.AsNoTracking().Include(x => x.Id).Select(x => x.ToTransfertObject()).ToList();

        public CourseTO GetById(int Id)
           => rsContext.Courses.AsNoTracking()
                                   .Include(x => x.Name)
                                   .FirstOrDefault(x => x.Id == Id)
                                   .ToTransfertObject();

        public bool Remove(CourseTO entity)
        {
            try
            {
                rsContext.Courses.Remove(entity.ToEF());
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
            throw new NotImplementedException();
        }
    }
}
