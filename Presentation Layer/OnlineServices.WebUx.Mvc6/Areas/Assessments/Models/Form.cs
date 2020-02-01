using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineServices.WebUx.Mvc6.Areas.Assessments.Models
{
	public class Form
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Nom { get; set; }
		[Required]
		public string Naam { get; set; }
	}
}
