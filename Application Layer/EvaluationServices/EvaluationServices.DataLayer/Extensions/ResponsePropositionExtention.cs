using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class ResponsePropositionExtention
    {
        public static ResponsePropositionTO ToTransfertObject(this ResponsePropositionEF proposition)
        {
            if (proposition is null) throw new ArgumentNullException(nameof(proposition));

            return new ResponsePropositionTO
            {
                Id = proposition.Id,
                QuestionProposition = proposition.QuestionProposition.ToTransfertObject(),
                Response = proposition.Responses.ToTransfertObject()
            };
        }
        public static ResponsePropositionEF ToEF(this ResponsePropositionTO proposition)
        {
            if (proposition is null) throw new ArgumentNullException(nameof(proposition));

            return new ResponsePropositionEF
            {
                Id = proposition.Id,
                QuestionPropositionId = proposition.QuestionProposition.Id,
                QuestionProposition=proposition.QuestionProposition.ToEF(),
                ResponseId=proposition.Response.Id,
                Responses = proposition.Response.ToEF(),
            };
        }

    }
}
