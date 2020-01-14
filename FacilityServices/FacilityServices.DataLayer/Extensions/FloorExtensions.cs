using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class FloorExtensions
    {
        public static FloorTO ToTransfertObject(this FloorEF Floor)
        {
            if (Floor is null)
                throw new NullFloorException(nameof(Floor));

            return new FloorTO
            {
                Id = Floor.Id,
                Number = Floor.Number,
                Archived = Floor.Archived,
            };
        }

        public static FloorEF ToEF(this FloorTO Floor)
        {
            if (Floor is null)
                throw new NullFloorException(nameof(Floor));

            return new FloorEF()
            {
                Id = Floor.Id,
                Number = Floor.Number,
                Archived = Floor.Archived,
            };
        }

        public static FloorEF UpdateFromDetached(this FloorEF AttachedEF, FloorEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new NullFloorException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new NullFloorException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update FloorEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Number = DetachedEF.Number;
                AttachedEF.Archived = DetachedEF.Archived;
            }
            return AttachedEF;
        }
    }
}
