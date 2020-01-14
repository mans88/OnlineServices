using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

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
            throw new System.NotImplementedException();
        }

        public RoomTO UpdateRoom(RoomTO roomToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}