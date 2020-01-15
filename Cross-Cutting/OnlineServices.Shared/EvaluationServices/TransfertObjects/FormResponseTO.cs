using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices
{
    public class FormResponseTO : IEntity<int>
    {
        public int Id { get; set; }
        public int FormModelID { get; set; }
        public int SessionID { get; set; }
        public DateTime Date { get; set; }
        public int AttendeeID { get; set; }
        List<ResponseTO> Responses { get; set; }
    }
}