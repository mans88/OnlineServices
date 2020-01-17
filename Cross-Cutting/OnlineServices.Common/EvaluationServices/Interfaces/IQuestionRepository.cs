using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.Interfaces
{
    public interface IQuestionRepository : IRepository<FormQuestionTO, int>
    {
        //FormQuestionTO Add(FormQuestionTO Entity);
        //IEnumerable<FormQuestionTO> GetAll();
        //FormQuestionTO GetByID(int Id);
        //bool Remove(FormQuestionTO entity);
        //bool Remove(int Id);
        //FormQuestionTO Update(FormQuestionTO Entity);
    }
}