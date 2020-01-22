using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class FormQuestionExtensions
    {
        public static FormQuestionTO ToTransfertObject(this FormQuestionEF form)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

             return new FormQuestionTO
            {
                Id = form.Id,
                Name = form.Name,
                Questions = form.Questions.Select(x => x.ToTransfertObject()).ToList()
            };
        }

        public static FormQuestionEF ToEF(this FormQuestionTO form)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

            return new FormQuestionEF
            {
                Id = form.Id,
                Name = form.Name,
                Questions = form.Questions.Select(x => x.ToEF()).ToList()
            };
        }
    }
}

