using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly FacilityContext facilityContext;

        public IncidentRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public IncidentTO Add(IncidentTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var incident = Entity.ToEF();
            incident.Issue = facilityContext.Issues.First(x => x.Id == Entity.Issue.Id);
            incident.Room = facilityContext.Rooms.First(x => x.Id == Entity.Room.Id);

            return facilityContext.Incidents.Add(incident).Entity.ToTransfertObject();
        }

        public IEnumerable<IncidentTO> GetAll()
        {
            return facilityContext.Incidents.AsNoTracking()
                .Include(i => i.Issue)
                .ThenInclude(i => i.ComponentType)
                .Include(i => i.Room)
                .ThenInclude(r => r.Floor)
                .Select(i => i.ToTransfertObject());
        }

        public IncidentTO GetById(int Id)
        {
            return facilityContext.Incidents.AsNoTracking()
                .Include(i => i.Issue)
                .ThenInclude(i => i.ComponentType)
                .Include(i => i.Room)
                .ThenInclude(r => r.Floor)
                .FirstOrDefault(x => x.Id == Id)
                .ToTransfertObject();
        }

        public List<IncidentTO> GetIncidentsByUserId(int UserId)
        {
            return facilityContext.Incidents.Where(i => i.UserId == UserId)
                .Select(i => i.ToTransfertObject())
                .ToList();
        }

        public bool Remove(IncidentTO entity)
        {
            if (!facilityContext.Incidents.Any(x => x.Id == entity.Id))
            {
                throw new KeyNotFoundException("No incident found !");
            }
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));

            }

            var entityEF = facilityContext.Incidents.Find(entity.Id);
            var tracking = facilityContext.Incidents.Remove(entityEF);
            return tracking.State == EntityState.Deleted;
        }

        public bool Remove(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("The ID isn't in the correct format!");
            }

            return Remove(GetById(Id));
        }

        public IncidentTO Update(IncidentTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }
            if (Entity.Id <= 0)
            {
                throw new ArgumentException("The Incident's ID is not in the correct format !");
            }

            if (!facilityContext.Incidents.Any(x => x.Id == Entity.Id))
            {
                throw new KeyNotFoundException("No incident found !");
            }

            var attachedIncident = facilityContext.Incidents
                .Include(i => i.Issue)
                .ThenInclude(i => i.ComponentType)
                .Include(i => i.Room)
                .ThenInclude(r => r.Floor)
                .FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedIncident != null)
            {
                attachedIncident.UpdateFromDetached(Entity.ToEF());
            }

            var tracking = facilityContext.Incidents.Update(attachedIncident);
            tracking.State = EntityState.Detached;

            return tracking.Entity.ToTransfertObject();
        }
    }
}