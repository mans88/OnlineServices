using FacilityServices.BusinessLayer;
using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class RoomExtensions
    {
        public static RoomTO ToTranfertsObject(this RoomEF Room)
        {
            if (Room is null)
                throw new ArgumentNullException(nameof(Room));

            return new RoomTO
            {
                Id = Room.Id,
                Name = new MultiLanguageString(Room.NameEnglish, Room.NameFrench, Room.NameDutch),
            };
        }

        public static RoomEF ToEF(this RoomTO Room)
        {
            if (Room is null)
                throw new ArgumentNullException(nameof(Room));

            return new RoomEF()
            {
                Id = Room.Id,
                NameEnglish = Room.Name.English,
                NameFrench = Room.Name.French,
                NameDutch = Room.Name.Dutch,
            };
        }
        //public static RoomEF UpdateFromDetached(this RoomEF AttachedEF, RoomEF DetachedEF)
        //{
        //    if (AttachedEF is null)
        //        throw new ArgumentNullException(nameof(AttachedEF));

        //    if (DetachedEF is null)
        //        throw new ArgumentNullException(nameof(DetachedEF));

        //    if (AttachedEF.Id != DetachedEF.Id)
        //        throw new Exception("Cannot update ComponentEF entity as it is not the same.");

        //    if ((AttachedEF != default) && (DetachedEF != default))
        //    {
        //        AttachedEF.Room = DetachedEF.Room;
        //        AttachedEF = AttachedEF.FillFromMultiLanguageString(DetachedEF.ExtractToMultiLanguageString());
        //    }

        //    return AttachedEF;
        //}
    }
}
