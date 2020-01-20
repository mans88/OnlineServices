using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
    [Table("QuestionProposition")]
    public class QuestionPropositionEF : IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Questions")]
        public int QuestionId { get; set; }
        public QuestionEF Question { get;  set; }

        public int Position { get; set; }
        public string NameEnglish { get; set;}
        public string NameFrench { get; set;}
        public string NameDutch { get; set; }
    }
}