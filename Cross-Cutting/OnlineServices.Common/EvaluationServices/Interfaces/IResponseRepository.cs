using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.Interfaces
{
    public interface IResponseRepository : IRepositoryTemp<FormResponseTO, int>
    {
        FormResponseTO Add(FormResponseTO Entity);
        IEnumerable<FormResponseTO> GetAll();
        FormResponseTO GetByID(int Id);
        bool Remove(FormResponseTO entity);
        bool Remove(int Id);
        FormResponseTO Update(FormResponseTO Entity);
    }
}