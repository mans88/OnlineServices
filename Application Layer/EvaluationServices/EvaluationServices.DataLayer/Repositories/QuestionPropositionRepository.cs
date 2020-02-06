using EvaluationServices.DataLayer.Entities;
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
		{
			if (Entity is null) throw new ArgumentNullException(nameof(Entity));

			var questionproposition = Entity.ToEF();
			questionproposition.Question = evaluationContext.Questions.FirstOrDefault(q => q.Id == Entity.Question.Id);

			return evaluationContext.QuestionPropositions.Add(questionproposition).Entity.ToTransfertObject();
		}

		public IEnumerable<QuestionPropositionTO> GetAll()
		{
			return evaluationContext.QuestionPropositions
				.AsNoTracking()
				.Include(qp => qp.Question)
					.ThenInclude(qp => qp.Form)
				.OrderBy(qp => qp.Question.Position)
					.ThenBy(qp => qp.Position)
				.Select(qp => qp.ToTransfertObject())
				.ToList();
		}

		public QuestionPropositionTO GetById(int Id)
		{
			return evaluationContext.QuestionPropositions
				.AsNoTracking()
				.Include(qp => qp.Question)
					.ThenInclude(qp => qp.Form)
				.FirstOrDefault(qp => qp.Id == Id)
				.ToTransfertObject();
		}

		public bool Remove(QuestionPropositionTO entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			return Remove(entity.Id);
		}

		public bool Remove(int Id)
		{
			var toRemove = evaluationContext.QuestionPropositions.FirstOrDefault(qp => qp.Id == Id);
			var removed = evaluationContext.QuestionPropositions.Remove(toRemove);
			return (removed.State == EntityState.Deleted);
		}

		public QuestionPropositionTO Update(QuestionPropositionTO Entity)
		{
			if (Entity is null)
				throw new Exception();

			return evaluationContext.QuestionPropositions.Update(Entity.ToEF()).Entity.ToTransfertObject();
		}
	}
}
