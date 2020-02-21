using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class QuestionPropositionExtention
    {
        public static QuestionPropositionTO ToTransfertObject(this QuestionPropositionEF proposition)
        {
            if (proposition is null) throw new ArgumentNullException(nameof(proposition));

            return new QuestionPropositionTO
            {
                Id = proposition.Id,
                Libelle = new MultiLanguageString(proposition.NameEnglish, proposition.NameFrench, proposition.NameDutch),
                Position = proposition.Position,
                QuestionId = proposition.Question.Id
            };
        }
        public static QuestionPropositionEF ToEF(this QuestionPropositionTO proposition)
        {
            if (proposition is null) throw new ArgumentNullException(nameof(proposition));

            return new QuestionPropositionEF
            {
                Id = proposition.Id,
                NameEnglish = proposition.Libelle.English,
                NameFrench = proposition.Libelle.French,
                NameDutch = proposition.Libelle.Dutch,
                Position = proposition.Position,
                Question = new QuestionEF()
            };
        }
    }
}
