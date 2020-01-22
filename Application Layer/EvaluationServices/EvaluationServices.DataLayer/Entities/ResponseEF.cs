using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.TranslationServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
    [Table("Responses")]
    public class ResponseEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FormResponse")]
        public int ResponseFormId { get; set; }
        public FormResponseEF Form { get; set; }


        [ForeignKey("QuestionProposition")]
        public int QuestionId { get; set; }
        public QuestionEF Question { get; set; }

        //public int Position { get; set; }

        public virtual ICollection<ResponsePropositionEF> Choices { get; set; }

        public string ResponseOpened { get; set; }
    }
}