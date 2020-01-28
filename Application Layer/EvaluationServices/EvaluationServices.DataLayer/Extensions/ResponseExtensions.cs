using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Linq;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class ResponseExtensions
    {
        public static ResponseTO ToTransfertObject(this ResponseEF response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            return new ResponseTO
            {
                Id = response.Id,
                Grade = response.Grade,
                MultiChoices = response.MultiChoices,
                Question = response.Question.ToTransfertObject(),
                Text = response.Text,
                QuestionProposition = response.QuestionProposition?.ToTransfertObject(),
                Comment = response.Comment?.ToTransfertObject(),
                Submission = response.Submission.ToTransfertObject(),
            };
        }

        public static ResponseEF ToEF(this ResponseTO response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            var answer = new ResponseEF
            {
                Id = response.Id,
                Grade = response.Grade,
                MultiChoices = response.MultiChoices,
                Question = response.Question.ToEF(),
                Text = response.Text,
                QuestionProposition = response.QuestionProposition?.ToEF(),
                Comment = response.Comment?.ToEF(),
                Submission = response.Submission.ToEF()
            };

            if(answer.Comment != default(CommentEF))
                answer.Comment.Response = answer;

            return answer;
        }
    }
}