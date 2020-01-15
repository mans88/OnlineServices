using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class IssueExtensions
    {
        public static Issue ToDomain(this IssueTO IssueTO)
        {
            return new Issue(IssueTO.Name)
            {
                Id = IssueTO.Id
            };
        }
        public static IssueTO ToTransfertObject(this Issue Issue)
        {
            return new IssueTO()
            {
                Id = Issue.Id,
                Name = Issue.Name,
            };
        }
    }
}
