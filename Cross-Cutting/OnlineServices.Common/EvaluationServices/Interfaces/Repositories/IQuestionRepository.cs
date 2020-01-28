using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.EvaluationServices.Interfaces.Repositories
{
	public interface IQuestionRepository : IRepository<QuestionTO, int>
	{
		// méthodes spécifiques au FormQuestionRepository à rajouter ??
		public IEnumerable<QuestionTO> GetAllOfForm(int FormId);
	}
}
