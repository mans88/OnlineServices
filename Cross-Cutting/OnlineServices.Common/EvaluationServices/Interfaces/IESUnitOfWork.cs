using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.EvaluationServices.Interfaces
{
    public interface IESUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }
        IResponseRepository ResponseRepository { get; }

        void Dispose();
        void Save();
    }
}
