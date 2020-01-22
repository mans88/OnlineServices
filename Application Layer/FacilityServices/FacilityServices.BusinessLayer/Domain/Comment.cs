using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Incident Incident { get; set; }
        public string Message { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
