using EvaluationServices.DataLayer.Extensions;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.DataLayer
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly EvaluationContext evaluationContext;

        public ResponseRepository(EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public FormResponseTO Add(FormResponseTO Entity)
        {
            return evaluationContext.FormResponse.Add(Entity.ToEF()).Entity.ToTransfertObject();
        }

        public IEnumerable<FormResponseTO> GetAll()
        {
            return evaluationContext.FormResponse.Select(x => x.ToTransfertObject()).ToList();
        }

        public FormResponseTO GetById(int Id)
        {
            return evaluationContext.FormResponse.FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        }

        public bool Remove(FormResponseTO entity)
        {
            try
            {
                evaluationContext.FormResponse.Remove(entity.ToEF());
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(int Id)
        {
            return Remove(GetById(Id));
        }

        public FormResponseTO Update(FormResponseTO Entity)
        {
            if (Entity is null)
                throw new Exception();

            return evaluationContext.FormResponse.Update(Entity.ToEF()).Entity.ToTransfertObject();
        }
    }
}
