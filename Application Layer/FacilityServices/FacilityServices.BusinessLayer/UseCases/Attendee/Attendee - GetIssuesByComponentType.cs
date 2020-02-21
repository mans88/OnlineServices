using FacilityServices.BusinessLayer.Extensions;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAttendeeRole
    {
        public List<IssueTO> GetIssuesByComponentType(int componentTypeId)
        {
            if (componentTypeId <= 0)
            {
                throw new LoggedException("The Issues cannot be reached without existing ComponentType ID");
            }

            var issues = unitOfWork.IssueRepository.GetIssuesByComponentType(componentTypeId);
            return issues.Select(f => f.ToDomain().ToTransfertObject()).ToList();
        }
    }
}
