using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public List<ComponentTypeTO> GetComponentTypesByRoom(int roomId)
        {
            if (roomId <= 0)
            {
                throw new LoggedException("The ComponentTypes cannot be reached without existing Room ID");
            }

            return unitOfWork.ComponentTypeRepository.GetComponentTypesByRoom(roomId);
        }
    }
}
