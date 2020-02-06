using AttendanceServices.DataLayer;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.EvaluationServices.Interfaces
{
    public interface IESUnitOfWork : IUnitOfWork
    {
        IFormRepository FormRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuestionPropositionRepository QuestionPropositionRepository { get; }
        IResponseRepository ResponseRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }
        ICommentRepository CommentRepository { get; }
    }
}
