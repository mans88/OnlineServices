using OnlineServices.Common.FacilityServices.TransfertObjects;

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
            throw new System.NotImplementedException();
        }
        public IssueTO UpdateIssue(IssueTO issueToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}