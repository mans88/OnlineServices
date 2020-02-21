using FacilityServices.BusinessLayer.Extensions;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAssistantRole
    {
        public CommentTO AddComment(CommentTO comment)
        {
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            if (comment.Id != 0)
                throw new LoggedException("The comment ID has to be 0 when adding a new comment.");

            if (comment.Incident is null)
            {
                throw new LoggedException("The comment has to reference an existing incident.");
            }

            // Todo check unique constraints, check if room + componenttype exists, etc.
            var addedComment = unitOfWork.CommentRepository.Add(comment);
            return addedComment.ToDomain().ToTransfertObject();
        }
    }
}