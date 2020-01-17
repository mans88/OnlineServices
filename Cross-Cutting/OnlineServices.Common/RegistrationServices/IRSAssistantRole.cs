using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices
{
    public interface IRSAssistantRoleUser
    {
        bool AddUser(UserTO user);
        bool UpdateUser(UserTO user);
        bool RemoveUser(UserTO user);
        List<UserTO> GetUsers();
        UserTO GetUserById(int id);
    }

    public interface IRSAssistantRoleSession
    {
        bool AddSession(SessionTO session);
        bool UpdateSession(SessionTO session);
        bool RemoveSession(SessionTO session);
        List<SessionTO> GetSessions();
        SessionTO GetSessionById(int id);
    }

    public interface IRSAssistantRoleCourse
    {
        bool AddCourse(CourseTO course);
        bool UpdateCourse(CourseTO course);
        bool RemoveCourse(CourseTO course);
        List<CourseTO> GetCourses();
        CourseTO GetCourseById(int id);

    }
}
