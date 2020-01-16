using FacilityServices.BusinessLayer.Extensions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public List<IssueTO> GetIssues()
        {
            var issues = unitOfWork.IssueRepository.GetAll()
                                                 .Select(f => f.ToDomain().ToTransfertObject());

            return issues.ToList();
        }
    }
}
