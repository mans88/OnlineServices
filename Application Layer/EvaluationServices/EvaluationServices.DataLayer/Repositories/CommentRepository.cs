using EvaluationServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationServices.DataLayer
{
    public class CommentRepository : ICommentRepository
    {
        private readonly EvaluationContext evaluationContext;

        public CommentRepository(EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public CommentTO Add(CommentTO Entity)
        {
            var comment = Entity.ToEF();
            comment.Response = evaluationContext.Responses.First(r => r.Id == Entity.Response.Id);

            return evaluationContext.Comments.Add(comment).Entity.ToTransfertObject();
        }

        public IEnumerable<CommentTO> GetAll()
        {
            return evaluationContext.Comments
                .Include(c => c.Response)
                .Select(x => x.ToTransfertObject());
             //return evaluationContext.Comments.Select(x => x.ToTransfertObject()).ToList();
        }

        public CommentTO GetById(int Id)
        {
            return evaluationContext.Comments.FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        }

        public bool Remove(CommentTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var toRemove = evaluationContext.Comments.First(c => c.Id == Id);
            var removed = evaluationContext.Comments.Remove(toRemove);
            return (removed.State == EntityState.Deleted);
        }

        public CommentTO Update(CommentTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var toUpdate = evaluationContext.Comments
                .First(s => s.Id == Entity.Id);

            toUpdate.Content = Entity.Content;
            toUpdate.Response = Entity.Response.ToEF();

            return evaluationContext.Comments.Update(toUpdate).Entity.ToTransfertObject();
        }
    }
}
