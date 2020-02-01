using EvaluationServices.DataLayer.Entities;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationServices.DataLayer.Extensions
{
	public static class SubmissionExtension
	{
		public static SubmissionTO ToTransfertObject(this SubmissionEF submission)
		{
			if (submission is null)
				throw new ArgumentNullException(nameof(submission));

			return new SubmissionTO
			{
				Id = submission.Id,
				AttendeeId = submission.AttendeeId,
				Date = submission.Date,
				Responses = submission.Responses.Select(r => r.ToTransfertObject()).ToList(),
				SessionId = submission.SessionId
			};
		}

		public static SubmissionEF ToEF(this SubmissionTO submission)
		{
			if (submission is null)
				throw new ArgumentNullException(nameof(submission));

			return new SubmissionEF
			{
				Id = submission.Id,
				SessionId = submission.SessionId,
				Date = submission.Date,
				Responses = submission.Responses.Select(r => r.ToEF()).ToList(),
				AttendeeId = submission.AttendeeId
			};
		}
	}
}
