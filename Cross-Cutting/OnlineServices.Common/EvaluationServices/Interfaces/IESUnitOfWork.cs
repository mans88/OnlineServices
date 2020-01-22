using AttendanceServices.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.EvaluationServices.Interfaces
{
    public interface IESUnitOfWork : IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }
        IResponseRepository ResponseRepository { get; }
    }
}
