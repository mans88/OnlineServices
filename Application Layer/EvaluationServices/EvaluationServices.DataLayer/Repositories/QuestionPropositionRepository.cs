using EvaluationServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.DataLayer.Repositories
{
	public class QuestionPropositionRepository : IQuestionPropositionRepository
	{
		// Context
		private readonly EvaluationContext evaluationContext;

		// Constructeur
		public QuestionPropositionRepository(EvaluationContext context)
		{
			evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)} in EvaluationRepository");
		}

		public QuestionPropositionTO Add(QuestionPropositionTO Entity)
			=> evaluationContext.QuestionProposition.Add(Entity.ToEF()).Entity.ToTransfertObject();


		public IEnumerable<QuestionPropositionTO> GetAll()
			=> evaluationContext.QuestionProposition.Select(q => q.ToTransfertObject()).ToList();

		public QuestionPropositionTO GetById(int Id)
			=> evaluationContext.QuestionProposition.FirstOrDefault(q => q.Id == Id).ToTransfertObject();

		public bool Remove(QuestionPropositionTO entity)
			=> Remove(entity.Id);
		
		public bool Remove(int Id)
		{
			var toRemove = evaluationContext.QuestionProposition.FirstOrDefault(q => q.Id == Id);
			var removed = evaluationContext.QuestionProposition.Remove(toRemove);
			return (removed.State == EntityState.Deleted);
		}

		public QuestionPropositionTO Update(QuestionPropositionTO Entity)
		{
			var toUpdate = evaluationContext.QuestionProposition.FirstOrDefault(q => q.Id == Entity.Id);

		}
	}
}
