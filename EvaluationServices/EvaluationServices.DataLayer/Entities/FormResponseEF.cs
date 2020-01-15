using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
    [Table("FormResponse")]
    public class FormResponseEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int SessionID { get; set; }
        public int AttendeeID { get; set; }
        public DateTime Date { get; set; }
        public ICollection<ResponseEF> Responses { get; set; }
    }
}
