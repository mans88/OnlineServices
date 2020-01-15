using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class QuestionTO : IEntity<int>
    {
        public  int Id { get; set; }
        public FormQuestionTO Form { get; set; }
        public QuestionType Type { get; set; }
        public int Position { get; set; }
        public MultiLanguageString Libelle { get; set; }
        public ICollection<QuestionPropositionTO> Choices { get; set; }
    }
}