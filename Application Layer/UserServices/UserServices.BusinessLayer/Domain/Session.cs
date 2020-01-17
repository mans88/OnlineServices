using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationServices.BusinessLayer
{
    public class Session
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        //public Local Local { get; set; }
        public User Teacher{ get; set; }
        public List<DateTime> Dates { get; set; }
        public List<User> Attendees { get; set; }
    }
}
