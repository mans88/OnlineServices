using System;
using System.Collections.Generic;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System.Linq;
using EvaluationServices.DataLayer.Extensions;
using OnlineServices.Common.EvaluationServices.Interfaces;

namespace EvaluationServices.DataLayer
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly EvaluationContext evaluationContext;

        public QuestionRepository (EvaluationContext context)
        {
            evaluationContext = context ?? throw new ArgumentNullException($"{nameof(context)}in EvaluationRepository");
        }

        public FormQuestionTO Add(FormQuestionTO Entity)
        {
            return evaluationContext.FormQuestion.Add(Entity.ToEF()).Entity.ToTransfertObject();
        }

        public IEnumerable<FormQuestionTO> GetAll()
        {
            return evaluationContext.FormQuestion.Select(x => x.ToTransfertObject()).ToList();
        }

        public FormQuestionTO GetById(int Id) =>evaluationContext.FormQuestion.FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        

        public bool Remove(FormQuestionTO entity)
        {
            try
            {
                evaluationContext.FormQuestion.Remove(entity.ToEF());
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

        public FormQuestionTO Update(FormQuestionTO Entity)
        {
            if (Entity is null)
                throw new Exception();

            return evaluationContext.FormQuestion.Update(Entity.ToEF()).Entity.ToTransfertObject();
        }
    }
}
