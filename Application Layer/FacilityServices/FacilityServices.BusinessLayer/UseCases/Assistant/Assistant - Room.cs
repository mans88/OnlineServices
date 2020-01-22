using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public RoomTO AddRoom(RoomTO room)
        {
            if (room is null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            return unitOfWork.RoomRepository.Add(room);
        }

        public bool RemoveRoom(int roomId)
        {
            if (roomId <= 0)
            {
                throw new LoggedException("The Room ID is not in the correct format ! An integer in required.");
            }

            if (!unitOfWork.RoomRepository.GetAll().Any(x => x.Id == roomId))
            {
                throw new KeyNotFoundException("No Room was found for the given ID!");
            }
            var room = unitOfWork.RoomRepository.GetById(roomId);

            return unitOfWork.RoomRepository.Update(room) != null;
        }

        public RoomTO UpdateRoom(RoomTO roomToUpdate)
        {
            if (roomToUpdate is null)
            {
                throw new ArgumentNullException("The Room object cannot be null !");
            }

            if (roomToUpdate.Id <= 0)
            {
                throw new LoggedException("The Room object cannot be updated without it's ID");
            }

            return unitOfWork.RoomRepository.Update(roomToUpdate);
        }
    }
}