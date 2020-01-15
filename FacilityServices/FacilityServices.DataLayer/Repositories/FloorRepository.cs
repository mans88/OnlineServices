using FacilityServices.DataLayer.Entities;
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
            .Select(x => x.ToTransfertObject())
            .ToList();

        public FloorTO GetById(int Id)
        {
            return facilityContext.Floors
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == Id)
            .ToTransfertObject();
        }

        public bool Remove(FloorTO entity)
        => Remove(entity.Id);


        public bool Remove(int Id)
        {
            if (!facilityContext.Floors.Any(x => x.Id == Id))
                throw new Exception($"FloorRepository. Delete(FloorId = {Id}) no record to delete.");

            var ReturnValue = false;

            var floor = facilityContext.Floors.FirstOrDefault(x => x.Id == Id);
            if (floor != default)
            {
                try
                {
                    facilityContext.Floors.Remove(floor);
                    ReturnValue = true;
                }
                catch (Exception)
                {
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        public FloorTO Update(FloorTO Entity)
        {
            if (!facilityContext.Floors.Any(x => x.Id == Entity.Id))
                throw new Exception($"FloorRepository. Update(FloorTransfertObject) no record to update.");

            var attachedFloors = facilityContext.Floors
                .FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedFloors != default)
            {
                attachedFloors.UpdateFromDetached(Entity.ToEF());
                //attachedFloors.FloorsComposition = attachedFloors.FloorsComposition
                //    .ToList()
                //    .UpdateListFromDetached(Entity.ToEF().FloorsComposition.ToList());
            }

            return facilityContext.Floors.Update(attachedFloors).Entity.ToTransfertObject();
        }
    }
}