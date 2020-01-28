using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;

namespace EvaluationServices.DataLayer.Extensions
{
    public static class Comment
    {
        public static CommentTO ToTransfertObject(this CommentEF comment)
        {
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            return new CommentTO
            {
                Id = comment.Id,
                Content = comment.Content,
            };
        }

        public static CommentEF ToEF(this CommentTO comment)
        {
            if (comment is null)
                throw new ArgumentNullException(nameof(comment));

            return new CommentEF
            {
                Id = comment.Id,
                Content = comment.Content,
            };
        }
    }
}
