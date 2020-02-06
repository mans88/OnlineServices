using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.EvaluationServices.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<CommentTO, int>
    {
        CommentTO GetById(int Id);
        bool Remove(CommentTO entity);
        bool Remove(int Id);
        CommentTO Update(CommentTO Entity);
    }
}
