using System;
using System.Collections.Generic;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System.Linq;
using EvaluationServices.DataLayer.Extensions;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvaluationServices.DataLayer.Repositories
{
    public class FormRepository : IFormRepository
    {
        // Context
        private readonly EvaluationContext evaluationContext;

        // Constructeur
        public FormRepository(EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public FormTO Add(FormTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));
            return evaluationContext.Forms
            .Add(Entity.ToEF())
            .Entity
            .ToTransfertObject();
        }
	
        public IEnumerable<FormTO> GetAll()
        {
            return evaluationContext.Forms
                .AsNoTracking()
                .Select(f => f.ToTransfertObject())
                .ToList();
        }

        public FormTO GetById(int Id)
        {
            return evaluationContext.Forms
                .AsNoTracking()
                .FirstOrDefault(f => f.Id == Id)
                .ToTransfertObject();
        }

        public bool Remove(FormTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var toRemove = evaluationContext
                .Forms
                .FirstOrDefault(f => f.Id == Id);

            var removed = evaluationContext
                .Forms
                .Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }
        public FormTO Update(FormTO Entity)
        {
            if (Entity is null)
                throw new Exception();

            return evaluationContext
                .Forms
                .Update(Entity.ToEF())
                .Entity
                .ToTransfertObject();
        }
    }
}
