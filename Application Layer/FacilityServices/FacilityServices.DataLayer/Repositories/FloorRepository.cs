using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly FacilityContext facilityContext;

        public FloorRepository(FacilityContext ContextIoC)
        {
            this.facilityContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in IngredientRepository");
        }

        public FloorTO Add(FloorTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            //return facilityContext.Update<FloorEF>(Entity.ToEF()).Entity.ToTransfertObject();

            //return facilityContext.Floors
            //    .Add(Entity.ToEF())
            //    .Entity
            //    .ToTransfertObject();

            var entity = facilityContext.Floors.Add(Entity.ToEF()).Entity;
            //facilityContext.SaveChanges();
            //return GetByID(entity.Id);
            return entity.ToTransfertObject();
        }

        public IEnumerable<FloorTO> GetAll()
        => facilityContext.Floors
            .AsNoTracking()
            .Where(f => f.Archived != true)
            .Select(x => x.ToTransfertObject())
            .ToList();

        public FloorTO GetById(int Id)
        {
            return facilityContext.Floors
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == Id && x.Archived != true)
            .ToTransfertObject();
        }

        public bool Remove(FloorTO entity)
        => Remove(entity.Id);


        public bool Remove(int Id)
        {
            var floor = facilityContext.Floors.FirstOrDefault(x => x.Id == Id && !x.Archived);

            if (floor is null)
            {
                throw new KeyNotFoundException($"FloorRepository. Remove(FloorId = {Id}) no record to delete.");
            }

            floor.Archived = true;
            return facilityContext.Floors.Update(floor).Entity.Archived;
        }

        public FloorTO Update(FloorTO Entity)
        {
            var attachedFloor = facilityContext.Floors.FirstOrDefault(x => x.Id == Entity.Id && !x.Archived);

            if (attachedFloor is null)
            {
                throw new KeyNotFoundException($"FloorRepository. Update(FloorTransfertObject) no record to update.");
            }

            attachedFloor.UpdateFromDetached(Entity.ToEF());
            //attachedFloors.FloorsComposition = attachedFloors.FloorsComposition
            //    .ToList()
            //    .UpdateListFromDetached(Entity.ToEF().FloorsComposition.ToList());

            return facilityContext.Floors.Update(attachedFloor).Entity.ToTransfertObject();
        }
    }
}