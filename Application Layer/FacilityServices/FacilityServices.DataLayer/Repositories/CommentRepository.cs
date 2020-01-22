using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private FacilityContext facilityContext;

        public CommentRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public CommentTO Add(CommentTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            var comment = Entity.ToEF();
            comment.Incident = facilityContext.Incidents.First(c => c.Id == Entity.Incident.Id);

            return facilityContext.Comments.Add(comment).Entity.ToTransfertObject();
        }

        public IEnumerable<CommentTO> GetAll()
        {
            return facilityContext.Comments
                .AsNoTracking()
                .Include(c => c.Incident)
                    .ThenInclude(i => i.Issue)
                        .ThenInclude(i => i.ComponentType)
                .Include(x => x.Incident)
                    .ThenInclude(i => i.Room)
                        .ThenInclude(r => r.Floor)
                .Select(c => c.ToTransfertObject())
                .ToList();
        }

        public CommentTO GetById(int Id)
        {
            var comment = facilityContext.Comments
                .AsNoTracking()
                .Include(c => c.Incident)
                    .ThenInclude(i => i.Issue)
                        .ThenInclude(i => i.ComponentType)
                .Include(x => x.Incident)
                    .ThenInclude(i => i.Room)
                        .ThenInclude(r => r.Floor)
                .FirstOrDefault(c => c.Id == Id);

            if (comment is null)
            {
                throw new KeyNotFoundException($"No comment with ID={Id} was found.");
            }

            return comment.ToTransfertObject();
        }

        public List<CommentTO> GetCommentsByIncidentId(int incidentId)
        {
            return facilityContext.Comments
                .Where(c => c.Incident.Id == incidentId)
                .Select(c => c.ToTransfertObject())
                .ToList();
        }

        public bool Remove(CommentTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var comment = facilityContext.Comments.FirstOrDefault(c => c.Id == Id);

            if (comment == null)
            {
                throw new ArgumentException($"CommentRepository. Delete(commentId = {Id}) no record to delete.");
            }
            var removedComment = facilityContext.Comments.Remove(comment);
            return removedComment.State == EntityState.Deleted;
        }

        public CommentTO Update(CommentTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            var comment = facilityContext.Comments
                .Include(c => c.Incident)
                    .ThenInclude(i => i.Issue)
                        .ThenInclude(i => i.ComponentType)
                .Include(x => x.Incident)
                    .ThenInclude(i => i.Room)
                        .ThenInclude(r => r.Floor)
                .FirstOrDefault(c => c.Id == Entity.Id);

            if (comment == null)
            {
                throw new ArgumentException($"CommentRepository. Update(commentTO) wrong ID (ID <= 0).");
            }

            comment.UpdateFromDetached(Entity.ToEF());

            var updatedComment = facilityContext.Comments.Update(comment);
            updatedComment.State = EntityState.Detached;
            return updatedComment.Entity.ToTransfertObject();
        }
    }
}