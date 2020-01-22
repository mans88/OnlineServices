using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using OnlineServices.Common.EvaluationServices.Enumerations;
using System.Linq;
using OnlineServices.Common.EvaluationServices;

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
                Form = response.Form.ToTransfertObject(),
                Question = response.Question.ToTransfertObject(),
                ResponseOpened = response.ResponseOpened,
                Choices = response.Choices?.Select(x => x.ToTransfertObject()).ToList(),
            };
        }

        public static ResponseEF ToEF(this ResponseTO response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            return new ResponseEF
            {
                Id = response.Id,
                Form = response.Form.ToEF(),
                Question = response.Question.ToEF(),
                QuestionId = response.Question.Id,
                ResponseFormId = response.Form.Id,
                ResponseOpened = response.ResponseOpened,
                Choices = response.Choices?.Select(c => c.ToEF()).ToList()
            };
        }
    }
}