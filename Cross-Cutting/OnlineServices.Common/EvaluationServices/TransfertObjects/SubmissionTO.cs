using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class SubmissionTO : IEntity<int>
    {
        public int Id { get; set; }
        public int AttendeeId { get; set; }
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public List<ResponseTO> Responses { get; set; }

    }
}