using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EvaluationServices.DataLayer.Entities
{
    [Table("Response")]
    public class ResponsePropositionEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Reponses")]
        public int ResponseId { get; set; }
        public ResponseEF Responses { get; set; }

        [ForeignKey("QuestionProposition")]
        public int QuestionPropositionId { get; set; }
        public QuestionPropositionEF QuestionProposition { get; set; }

    }
}
