using FacilityServices.BusinessLayer.Domain;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class FloorExtensions
    {
        public static Floor ToDomain(this FloorTO FloorTO)
        {
            if (FloorTO is null)
            {
                throw new NullFloorException(nameof(FloorTO));
            }

            return new Floor()
            {
                Id = FloorTO.Id,
                Number = FloorTO.Number,
                Archived = FloorTO.Archived,
            };
        }
        public static FloorTO ToTransfertObject(this Floor Floor)
        {
            if (Floor is null)
            {
                throw new NullFloorException(nameof(Floor));
            }

            return new FloorTO()
            {
                Id = Floor.Id,
                Number = Floor.Number,
                Archived = Floor.Archived,
            };
        }
    }
}
