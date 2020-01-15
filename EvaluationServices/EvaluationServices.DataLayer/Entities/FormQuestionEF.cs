using System;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EvaluationServices.DataLayer.Entities
{
	[Table ("FormQuestion")]

	public class FormQuestionEF : IEntity<int>
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<QuestionEF> Questions { get; set; }
	}
}
