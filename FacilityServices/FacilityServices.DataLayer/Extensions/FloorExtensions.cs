using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class FloorExtensions
    {
        public static FloorTO ToTranfertsObject(this FloorEF Floor)
        {
            if (Floor is null)
                throw new ArgumentNullException(nameof(Floor));

            return new FloorTO
            {
                Id = Floor.Id,
                Name = Floor.Name,
            };
        }

        public static FloorEF ToEF(this FloorTO Floor)
        {
            if (Floor is null)
                throw new ArgumentNullException(nameof(Floor));

            return new FloorEF()
            {
                Id = Floor.Id,
                Name = Floor.Name,
            };
        }
    }
}
