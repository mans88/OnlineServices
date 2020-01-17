using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public CommentTO AddComment(CommentTO comment)
        {
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            if (comment.Id != 0)
                throw new Exception("Existing comment");

            try
            {
                var addedComment = unitOfWork.CommentRepository.Add(comment);
                return addedComment;
            }
            catch (LoggedException ex)
            {
                // Todo
                throw;
            }
            catch (Exception ex)
            {
                // Todo
                throw;
            }
        }
    }
}