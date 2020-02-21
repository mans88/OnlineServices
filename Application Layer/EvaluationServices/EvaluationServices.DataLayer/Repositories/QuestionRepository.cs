using EvaluationServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.DataLayer.Repositories
{
	public class QuestionRepository : IQuestionRepository
	{
		// Context
		private readonly EvaluationContext evaluationContext;

		// Constructeur
		public QuestionRepository(EvaluationContext context)
		{
			evaluationContext =
				context ?? throw new ArgumentNullException($"{ nameof(context) } in EvaluationRepository");
		}

		public QuestionTO Add(QuestionTO Entity)
		{
			if (Entity is null)
				throw new ArgumentNullException(nameof(Entity));

			var question = Entity.ToEF();
			question.Form = evaluationContext
				.Forms
				.FirstOrDefault(f => f.Id == Entity.FormId);
			return evaluationContext.Questions.Add(question).Entity.ToTransfertObject();
		}

		public IEnumerable<QuestionTO> GetAll()
		{
			return evaluationContext.Questions
				.AsNoTracking()
				.Include(q => q.Form)
				.OrderBy(q => q.Position)
				.Select(q => q.ToTransfertObject())
				.ToList();
		}

		public IEnumerable<QuestionTO> GetAllOfForm(int FormId)
		{
			return GetAll().Where(x => x.FormId == FormId);
		}

		public QuestionTO GetById(int Id)
		{
			return evaluationContext.Questions
				.AsNoTracking()
				.Include(q => q.Form)
				.Include(q => q.Propositions)
				.FirstOrDefault(q => q.Id == Id)
				.ToTransfertObject();
		}

		public bool Remove(QuestionTO entity)
		{
			if (entity is null)
				throw new ArgumentNullException(nameof(entity));

			return Remove(entity.Id);
		}

		public bool Remove(int Id)
		{
			var toRemove = evaluationContext.Questions
				.FirstOrDefault(q => q.Id == Id);

			var removed = evaluationContext.Questions.Remove(toRemove);

			return removed.State == EntityState.Deleted;
		}

		public QuestionTO Update(QuestionTO Entity)
		{
			throw new NotImplementedException();
		}
	}
}
