using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace OnlineServices.Common.FacilityServices.Interfaces.Repositories
{
    public interface IIssueRepository : IRepository<IssueTO, int>
    {
        List<IssueTO> GetIssuesByComponentType(ComponentTypeTO ComponentType);
    }
}
