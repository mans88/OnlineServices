using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private FacilityContext facilityContext;

        public IssueRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public IssueTO Add(IssueTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var issueEF = Entity.ToEF();
            issueEF.ComponentType = facilityContext.ComponentTypes.First(x => x.Id == Entity.ComponentType.Id);
            issueEF.ComponentType = issueEF.ComponentType.UpdateFromDetached(Entity.ComponentType.ToEF());

            return facilityContext.Issues.Add(issueEF).Entity.ToTransfertObject();
        }

        public IEnumerable<IssueTO> GetAll()
        {
            return facilityContext.Issues
                .Include(i => i.ComponentType)
                .Where(i => i.Archived != true)
                .Select(x => x.ToTransfertObject())
                .ToList();
        }

        public IssueTO GetById(int Id)
        {
            return facilityContext.Issues
                .Include(i => i.ComponentType)
                .FirstOrDefault(x => x.Id == Id && x.Archived != true)
                .ToTransfertObject();
        }

        public List<IssueTO> GetIssuesByComponentType(int componentTypeId)
        {
            if (componentTypeId <= 0)
            {
                throw new ArgumentException($"GetIssuesByComponentType: invalid componentType ID (ID={componentTypeId})");
            }

            var componentTypeEF = facilityContext.ComponentTypes.FirstOrDefault(x => x.Id == componentTypeId && !x.Archived);

            if (componentTypeEF is null)
            {
                throw new KeyNotFoundException($"GetIssuesByComponentType: no componentType found with ID={componentTypeId}");
            }

            return facilityContext.Issues
                .Include(i => i.ComponentType)
                .Where(i => i.ComponentType.Id == componentTypeId && i.Archived != true)
                .Select(i => i.ToTransfertObject())
                .ToList();
        }

        public bool Remove(IssueTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Remove(entity.Id);
        }

        public bool Remove(int Id)
        {
            var issue = facilityContext.Issues.FirstOrDefault(x => x.Id == Id && !x.Archived);

            if (issue is null)
            {
                throw new KeyNotFoundException($"IssueRepository. Remove(Id = {Id}) no record to delete.");
            }

            issue.Archived = true;
            return facilityContext.Issues.Update(issue).Entity.Archived; ;
        }

        public IssueTO Update(IssueTO Entity)
        {
            if (!facilityContext.Issues.Any(x => x.Id == Entity.Id && x.Archived != true))
                throw new LoggedException($"IssueRepository. Update(IssueTransfertObject) no record to update.");

            var attachedIssues = facilityContext.Issues
                .FirstOrDefault(x => x.Id == Entity.Id && x.Archived != true);

            if (attachedIssues != default)
            {
                attachedIssues.UpdateFromDetached(Entity.ToEF());
            }

            return facilityContext.Issues.Update(attachedIssues).Entity.ToTransfertObject();
        }
    }
}