using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class QuestionPropositionTO : IEntity<int>
    {
        public int Id { get; set;}
        public int QuestionId { get; set; }
        public int Position { get; set; }
        public MultiLanguageString Libelle { get; set; }
    }
}
