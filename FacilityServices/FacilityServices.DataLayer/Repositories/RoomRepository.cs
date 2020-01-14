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
    public class RoomRepository : IRoomRepository
    {
        private FacilityContext facilityContext;

        public RoomRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public RoomTO Add(RoomTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var roomEf = Entity.ToEF();
            roomEf.Floor = facilityContext.Floors.First(x => x.Id == Entity.Floor.Id);

            return facilityContext.Rooms.Add(roomEf).Entity.ToTransfertObject();        
        }

        public IEnumerable<RoomTO> GetAll()
        {
            return facilityContext.Rooms
                .Include(r => r.Floor)
                .Include(r => r.RoomComponents)
                .Select(r => r.ToTransfertObject());
        }

        public RoomTO GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("The ID isn't in the correct format!");
            }

            return facilityContext.Rooms
                .AsNoTracking()
                .Include(r => r.Floor)
                .Include(r => r.RoomComponents)
                .FirstOrDefault(r => r.Id == Id).ToTransfertObject();
        }

        public List<RoomTO> GetRoomsByFloors(FloorTO Floor)
        {
            if (Floor is null)
            {
                throw new ArgumentNullException(nameof(Floor));
            }

            return facilityContext.Rooms
                                  .Include(r => r.Floor)
                                  .Where(r => r.Floor.Id == Floor.Id)
                                  .Select(r => r.ToTransfertObject())
                                  .ToList();
        }

        public bool Remove(RoomTO entity)
        {
            if (!facilityContext.Rooms.Any(x => x.Id == entity.Id))
            {
                throw new KeyNotFoundException("No room found !");
            }

            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entityEF = facilityContext.Rooms.Find(entity.Id);
            var tracking = facilityContext.Rooms.Remove(entityEF);
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

        public RoomTO Update(RoomTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            var attachedRoom = facilityContext.Rooms.FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedRoom != default)
            {
                attachedRoom.UpdateFromDetached(Entity.ToEF());
            }

            if (!facilityContext.Rooms.Any(x => x.Id == Entity.Id))
            {
                throw new KeyNotFoundException("No room found !");
            }

            var tracking = facilityContext.Rooms.Update(attachedRoom);
            tracking.State = EntityState.Detached;
            //var entity = facilityContext.Rooms.Update(attachedRoom).Entity.ToTransfertObject();
            //facilityContext.SaveChanges();
            return tracking.Entity.ToTransfertObject();
        }
    }
}