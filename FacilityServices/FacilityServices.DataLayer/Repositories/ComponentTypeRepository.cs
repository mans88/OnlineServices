using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        private FacilityContext facilityContext;

        public ComponentTypeRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public ComponentTypeTO Add(ComponentTypeTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            return facilityContext.ComponentTypes
                .Add(Entity.ToEF())
                .Entity
                .ToTransfertObject();
        
        }

        public IEnumerable<ComponentTypeTO> GetAll()
        {
            return facilityContext.ComponentTypes
                .AsNoTracking()
                .Include(r => r.RoomComponents)
                .Select(x => x.ToTransfertObject())
                .ToList();
        }

        public ComponentTypeTO GetById(int Id)
        {
            return facilityContext.ComponentTypes
            .AsNoTracking()
            .Include(r => r.RoomComponents)
            .FirstOrDefault(x => x.Id == Id)
            .ToTransfertObject();
        }

        public List<ComponentTypeTO> GetComponentTypesByRoom(RoomTO Room)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ComponentTypeTO entity)
        => Remove(entity.Id);

        public bool Remove(int Id)
        {
            if (!facilityContext.ComponentTypes.Any(x => x.Id == Id))
                throw new Exception($"ComponentTypeRepository. Delete(ComponentTypeId = {Id}) no record to delete.");

            var ReturnValue = false;

            var componentType = facilityContext.ComponentTypes.FirstOrDefault(x => x.Id == Id);
            if (componentType != default)
            {
                try
                {
                    facilityContext.ComponentTypes.Remove(componentType);
                    ReturnValue = true;
                }
                catch (Exception)
                {
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        public ComponentTypeTO Update(ComponentTypeTO Entity)
        {
            if (!facilityContext.ComponentTypes.Any(x => x.Id == Entity.Id))
                throw new Exception($"ComponentTypeRepository. Update(ComponentTypeTransfertObject) no record to update.");

            var attachedComponentTypes = facilityContext.ComponentTypes
                .FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedComponentTypes != default)
            {
                attachedComponentTypes.UpdateFromDetached(Entity.ToEF());
            }

            return facilityContext.ComponentTypes.Update(attachedComponentTypes).Entity.ToTransfertObject();
        }
    }
}