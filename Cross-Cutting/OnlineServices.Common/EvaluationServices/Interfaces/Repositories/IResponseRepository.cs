using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices.Interfaces
{
    public interface IResponseRepository : IRepository<ResponseTO, int>
    {
        ResponseTO GetById(int Id);
        bool Remove(ResponseTO entity);
        bool Remove(int Id);
        ResponseTO Update(ResponseTO Entity);
        public IEnumerable<ResponseTO> GetAllOfForm(int FormId);
    }
}