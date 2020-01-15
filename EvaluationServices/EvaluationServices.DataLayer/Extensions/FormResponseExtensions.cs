using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class FormResponseExtensions
    {
        public static FormResponseTO ToTransfertObject(this FormResponseEF form)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

             return new FormResponseTO
             {
                Id = form.Id,
                AttendeeID=form.AttendeeID,
                Date=form.Date,
                SessionID=form.SessionID
            };
        }

        public static FormResponseEF ToEF(this FormResponseTO form)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

            return new FormResponseEF
            {
                Id = form.Id,
                AttendeeID = form.AttendeeID,
                Date = form.Date,
                SessionID=form.SessionID
            };
        }
    }
}

