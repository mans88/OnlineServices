using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class FloorExtensions
    {
        public static Floor ToDomain(this FloorTO FloorTO)
        {
            return new Floor(FloorTO.Name)
            {
                Id = FloorTO.Id
            };
        }
        public static FloorTO ToTransfertObject(this Floor Floor)
        {
            return new FloorTO()
            {
                Id = Floor.Id,
                Name = Floor.Name,
            };
        }
    }
}
