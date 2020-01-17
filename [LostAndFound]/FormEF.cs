using System;
using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.EvaluationServices.Enumarations;
using OnlineServices.Shared.TranslationServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
	[Table ("Evaluation")]

	public class FormEF : IEntity<int>, IMultiLanguageNameFields
	{
		[Key]
		public int Id { get; set; }
	}
}
