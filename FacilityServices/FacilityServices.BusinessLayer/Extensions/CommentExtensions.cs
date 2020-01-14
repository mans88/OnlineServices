using FacilityServices.BusinessLayer.Domain;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class CommentExtensions
    {
        public static Comment ToDomain(this CommentTO CommentTO)
        {
            return new Comment()
            {
                Id = CommentTO.Id,
                Incident = CommentTO.Incident.ToDomain(),
                Message = CommentTO.Message,
                SubmitDate = CommentTO.SubmitDate,
                UserId = CommentTO.UserId,

            };
        }
        public static CommentTO ToTransfertObject(this Comment Comment)
        {
            return new CommentTO()
            {
                Id = Comment.Id,
                Incident = Comment.Incident.ToTransfertObject(),
                Message = Comment.Message,
                SubmitDate = Comment.SubmitDate,
                UserId = Comment.UserId,
            };
        }
    }
}