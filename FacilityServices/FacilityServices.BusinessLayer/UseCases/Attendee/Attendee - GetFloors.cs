using FacilityServices.BusinessLayer.Extensions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public List<FloorTO> GetFloors()
        {
            var floors = unitOfWork.FloorRepository
                                   .GetAll()
                                   .Select(f => f.ToDomain().ToTransfertObject());

            return floors.ToList();
        }
    }
}