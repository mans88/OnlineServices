using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class FormTO : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public MultiLanguageString Name { get; set; }
    }
}