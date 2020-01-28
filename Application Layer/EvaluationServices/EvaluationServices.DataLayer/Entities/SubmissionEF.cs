using System;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EvaluationServices.DataLayer.Entities
{
	[Table ("Submissions")]

	public class SubmissionEF : IEntity<int>
	{
		[Key]
		public int Id { get; set; }
		public int AttendeeId { get; set; }
		public int SessionId { get; set; }
		public DateTime Date { get; set; }
		public virtual ICollection<ResponseEF> Responses { get; set; } 
	}
}
