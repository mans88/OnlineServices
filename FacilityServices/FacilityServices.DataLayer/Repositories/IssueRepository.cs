using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
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
                .Select(x => x.ToTransfertObject())
                .ToList();
        }

        public IssueTO GetById(int Id)
        {
            return facilityContext.Issues
                .Include(i => i.ComponentType)
                .FirstOrDefault(x => x.Id == Id)
                .ToTransfertObject();
        }

        public List<IssueTO> GetIssuesByComponentType(ComponentTypeTO ComponentType)
        {
            if (ComponentType is null)
            {
                throw new ArgumentNullException(nameof(ComponentType));
            }
            return facilityContext.Issues
                           .Include(r => r.ComponentType)
                           .Where(r => r.ComponentType.Id == ComponentType.Id)
                           .Select(r => r.ToTransfertObject())
                           .ToList();

        }

        public bool Remove(IssueTO entity)
        => Remove(entity.Id);

        public bool Remove(int Id)
        {
            if (!facilityContext.Issues.Any(x => x.Id == Id))
                throw new Exception($"IssueRepository. Delete(IssueId = {Id}) no record to delete.");

            var ReturnValue = false;

            var issue = facilityContext.Issues.FirstOrDefault(x => x.Id == Id);
            if (issue != default)
            {
                try
                {
                    facilityContext.Issues.Remove(issue);
                    ReturnValue = true;
                }
                catch (Exception)
                {
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        public IssueTO Update(IssueTO Entity)
        {
            if (!facilityContext.Issues.Any(x => x.Id == Entity.Id))
                throw new Exception($"IssueRepository. Update(IssueTransfertObject) no record to update.");

            var attachedIssues = facilityContext.Issues
                .FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedIssues != default)
            {
                attachedIssues.UpdateFromDetached(Entity.ToEF());
            }

            return facilityContext.Issues.Update(attachedIssues).Entity.ToTransfertObject();
        }
    }
}