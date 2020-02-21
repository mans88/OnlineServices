using EvaluationServices.DataLayer.Entities;
using EvaluationServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationServices.DataLayer
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly EvaluationContext evaluationContext;

        public SubmissionRepository(EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public SubmissionTO Add(SubmissionTO Entity)
        {
            return evaluationContext.Submissions.Add(Entity.ToEF()).Entity.ToTransfertObject();
        }

        public IEnumerable<SubmissionTO> GetAll()
        {
            return evaluationContext.Submissions.Select(x => x.ToTransfertObject()).ToList();
        }

        public SubmissionTO GetById(int Id)
        {
            return evaluationContext.Submissions.FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        }

        public bool IsAlreadySubmitted(int attendeeID, int sessionId, int formId)
        {
            return GetAll().Any(x=> (x.SessionId==sessionId)&&x.Responses.Any(y=>y.Question.FormId == formId) &&(x.AttendeeId==attendeeID));
        }

        public bool Remove(SubmissionTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var toRemove = evaluationContext.Submissions
                .First(s => s.Id == Id);

            var removed = evaluationContext.Submissions.Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }



        public SubmissionTO Update(SubmissionTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var toUpdate = evaluationContext.Submissions
                .First(s => s.Id == Entity.Id);

            toUpdate.Date = Entity.Date;
            toUpdate.AttendeeId = Entity.AttendeeId;
            toUpdate.SessionId = Entity.SessionId;

            return evaluationContext.Submissions.Update(toUpdate).Entity.ToTransfertObject();
        }
    }   
}
