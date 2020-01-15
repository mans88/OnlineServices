using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public CommentTO AddComment(CommentTO comment) 
        {
            if (comment is null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            return unitOfWork.CommentRepository.Add(comment);
        }
    }
}