using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class FormTO : IEntity<int>
    {
        public int Id { get; set; }
        public int SessionID { get; set; }
        public Dictionary<int, QuestionsTO> Questions { get; set; }
    }
}