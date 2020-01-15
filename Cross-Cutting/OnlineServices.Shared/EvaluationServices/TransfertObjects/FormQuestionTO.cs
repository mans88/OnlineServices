using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class FormQuestionTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int SessionID { get; set; }
        public List<QuestionTO> Questions { get; set; }
    }
}