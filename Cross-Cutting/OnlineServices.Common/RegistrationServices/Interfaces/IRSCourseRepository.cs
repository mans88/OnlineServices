using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSCourseRepository : IRepository<CourseTO, int>
    {
        IEnumerable<CourseTO> GetCourses(SessionTO session);

    }
}
