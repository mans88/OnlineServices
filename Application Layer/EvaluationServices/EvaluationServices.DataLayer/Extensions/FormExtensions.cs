using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class FormExtensions
    {
        public static FormTO ToTransfertObject(this FormEF form)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

            return new FormTO
            {
                Id = form.Id,
                Name = new MultiLanguageString(form.NameEnglish, form.NameFrench, form.NameDutch)
            };
        }

        public static FormEF ToEF(this FormTO form)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

            return new FormEF
            {
                Id = form.Id,
                NameEnglish = form.Name.English,
                NameFrench = form.Name.French,
                NameDutch = form.Name.Dutch,
            };
        }
    }
}

