using EvaluationServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationServices.DataLayer
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly EvaluationContext evaluationContext;

        public ResponseRepository(EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public ResponseTO Add(ResponseTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var response = Entity.ToEF();

            response.Question = evaluationContext
                .Questions
                .First(q => q.Id == Entity.Question.Id);

            response.Submission = evaluationContext
                .Submissions
                .First(s => s.Id == Entity.Submission.Id);

            if (String.IsNullOrEmpty(Entity.MultiChoices) && String.IsNullOrEmpty(Entity.Text))
            {
                response.QuestionProposition = evaluationContext
                    .QuestionPropositions
                    .First(q => q.Id == Entity.QuestionProposition.Id);
            }

            return evaluationContext.Responses.Add(response).Entity.ToTransfertObject();

        }

        public IEnumerable<ResponseTO> GetAll()
        {
            return evaluationContext.Responses.Select(x => x.ToTransfertObject()).ToList();
        }

        public IEnumerable<ResponseTO> GetAllOfForm(int FormId)
        {
            return GetAll().Where(x => x.Question.FormId == FormId);
        }

        public ResponseTO GetById(int Id)
        {
            return evaluationContext.Responses.FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        }

        public bool Remove(ResponseTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var toRemove = evaluationContext.Responses
                .First(r => r.Id == Id);

            var removed = evaluationContext.Responses.Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }

        public ResponseTO Update(ResponseTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var toUpdate = evaluationContext.Responses
               .First(s => s.Id == Entity.Id);

           // toUpdate.Id = Entity.Id;
            toUpdate.MultiChoices = Entity.MultiChoices;
            toUpdate.Grade = Entity.Grade;
            toUpdate.Question = Entity.Question.ToEF();
            toUpdate.QuestionProposition = Entity.QuestionProposition.ToEF();
            toUpdate.Submission = Entity.Submission.ToEF();
            toUpdate.Text = Entity.Text;

            return evaluationContext.Responses.Update(toUpdate).Entity.ToTransfertObject();

        }
    }
}
