using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using OnlineServices.Common.EvaluationServices.Enumerations;
using System.Linq;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class QuestionExtensions
    {

        public static QuestionTO ToTransfertObject(this QuestionEF question)
        {
            if (question is null)
                throw new ArgumentNullException(nameof(question));

            return new QuestionTO
            {
                Id = question.Id,
                Libelle = new MultiLanguageString(question.NameEnglish, question.NameFrench, question.NameDutch),
                Form = question.Form.ToTransfertObject(),
                Position = question.Position,
                Type = question.Type,
                Choices = question.Choices?.Select(x => x.ToTransfertObject()).ToList(),
              
            };
        }

        public static QuestionEF ToEF(this QuestionTO question)
        {
            if (question is null)
                throw new ArgumentNullException(nameof(question));

            return new QuestionEF
            {
                Id = question.Id,
                NameEnglish = question.Libelle.English,
                NameFrench = question.Libelle.French,
                NameDutch = question.Libelle.Dutch,
                Position = question.Position,
                Type = question.Type,
                Choices = question.Choices?.Select(c => c.ToEF()).ToList(),
                FormQuestionId=question.Form.Id
            };
        }
    }
}