using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.TranslationServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
    [Table("Questions")]
    public class QuestionEF : IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FormQuestion")]
        public int FormQuestionId { get; set; }
        public FormQuestionEF Form { get; set; }

        public QuestionType Type { get; set; }

        public int Position { get; set; }
        public string NameEnglish { get; set;}
        public string NameFrench { get; set;}
        public string NameDutch { get; set; }

        public virtual ICollection<QuestionPropositionEF> Choices { get; set; }
    }
}