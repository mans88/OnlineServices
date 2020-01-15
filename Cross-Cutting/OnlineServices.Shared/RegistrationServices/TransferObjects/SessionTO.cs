using OnlineServices.Common.DataAccessHelpers;

using System.Collections.Generic;

namespace OnlineServices.Common.RegistrationServices.TransferObject
{
    public class SessionTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public UserTO Teacher { get; set; }
        public CourseTO Course { get; set; }
        public List<SessionDayTO> SessionDays { get; set; } = new List<SessionDayTO>();
        public List<UserTO> Attendees { get; set; } = new List<UserTO>();
    }
}