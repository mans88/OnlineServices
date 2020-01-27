using FacilityServices.BusinessLayer.Domain;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Linq;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class RoomExtensions
    {
        public static Room ToDomain(this RoomTO RoomTO)
        {
            if (RoomTO is null)
                throw new NullRoomException(nameof(RoomTO));

            return new Room
            {
                Id = RoomTO.Id,
                Archived = RoomTO.Archived,
                Floor = RoomTO.Floor.ToDomain(),
                Name = RoomTO.Name,
                ComponentTypes = RoomTO.ComponentTypes?.Select(x=>x.ToDomain()).ToList(),
            };
        }

        public static RoomTO ToTransfertObject(this Room Room)
        {
            if (Room is null)
                throw new NullRoomException(nameof(Room));

            return new RoomTO
            {
                Id = Room.Id,
                Name = Room.Name,
                Floor = Room.Floor.ToTransfertObject(),
                Archived = Room.Archived,
                ComponentTypes = Room.ComponentTypes?.Select(x => x.ToTransfertObject()).ToList(),
            };
        }
    }
}
