using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class QuestionTO : IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public FormTO Form { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public MultiLanguageString Libelle { get; set; }
        public List<QuestionPropositionTO> Propositions { get; set; }
    }
}