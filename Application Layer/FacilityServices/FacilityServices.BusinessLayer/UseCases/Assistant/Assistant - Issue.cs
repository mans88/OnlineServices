using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public IssueTO AddIssue(IssueTO issueToAdd)
        {
            if (issueToAdd is null)
            {
                throw new System.ArgumentNullException(nameof(issueToAdd));
            }

            return unitOfWork.IssueRepository.Add(issueToAdd);
        }

        public bool RemoveIssue(int issueId)
        {
            if (issueId <= 0)
            {
                throw new LoggedException("The Issue ID is not in the correct format ! An integer in required.");
            }

            if (!unitOfWork.IssueRepository.GetAll().Any(x => x.Id == issueId))
            {
                throw new KeyNotFoundException("No Issue was found for the given ID!");
            }
            var issue = unitOfWork.IssueRepository.GetById(issueId);

            return unitOfWork.IssueRepository.Update(issue) != null;
        }
        public IssueTO UpdateIssue(IssueTO issueToUpdate)
        {
            if (issueToUpdate is null)
            {
                throw new ArgumentNullException("The Issue object cannot be null !");
            }

            if (issueToUpdate.Id <= 0)
            {
                throw new LoggedException("The Issue object cannot be updated without it's ID");
            }

            return unitOfWork.IssueRepository.Update(issueToUpdate);
        }
    }
}