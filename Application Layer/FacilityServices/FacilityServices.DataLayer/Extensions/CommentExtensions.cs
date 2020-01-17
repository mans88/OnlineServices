using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.DataLayer.Extensions
{
    public static class CommentExtensions
    {
        public static CommentTO ToTransfertObject(this CommentEF comment)
        {
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            return new CommentTO
            {
                Id = comment.Id,
                Incident = comment.Incident.ToTransfertObject(),
                Message = comment.Message,
                SubmitDate = comment.SubmitDate,
                UserId = comment.UserId,
            };
        }

        public static CommentEF ToEF(this CommentTO comment)
        {
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            return new CommentEF
            {
                Id = comment.Id,
                Incident = comment.Incident.ToEF(),
                Message = comment.Message,
                SubmitDate = comment.SubmitDate,
                UserId = comment.UserId,
            };
        }

        public static CommentEF UpdateFromDetached(this CommentEF attachedEF, CommentEF detachedEF)
        {
            if (attachedEF is null)
                throw new ArgumentNullException(nameof(attachedEF));

            if (detachedEF is null)
                throw new ArgumentNullException(nameof(detachedEF));

            if (attachedEF.Id != detachedEF.Id)
                throw new Exception("Cannot update CommentEF entity as it is not the same.");

            if ((attachedEF != default) && (detachedEF != default))
            {
                attachedEF.Incident = detachedEF.Incident;
                attachedEF.Message = detachedEF.Message;
                attachedEF.SubmitDate = detachedEF.SubmitDate;
                attachedEF.UserId = detachedEF.UserId;
            }

            return attachedEF;
        }
    }
}
