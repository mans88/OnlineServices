using OnlineServices.Common.DataAccessHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
    [Table("Forms")]

    public class FormEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public virtual ICollection<QuestionEF> Questions { get; set; }
    }
}
