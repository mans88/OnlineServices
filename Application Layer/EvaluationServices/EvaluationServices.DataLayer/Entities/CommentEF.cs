using OnlineServices.Common.DataAccessHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationServices.DataLayer.Entities
{
	[Table("Comments")]
	public class CommentEF : IEntity<int>
	{
		[Key]
		public int Id { get; set; }
		public string Content { get; set; }
		
		[ForeignKey("Response")]
		public int ResponseId { get; set; }
		public ResponseEF Response { get; set; }
	}
}