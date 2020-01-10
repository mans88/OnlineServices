using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class ComponentExtensions
    {
        public static ComponentTO ToTranfertsObject(this ComponentEF Component)
        {
            if (Component is null)
                throw new ArgumentNullException(nameof(Component));

            return new ComponentTO
            {
                Id = Component.Id,
                Name = new MultiLanguageString(Component.NameEnglish, Component.NameFrench, Component.NameDutch),
            };
        }

        public static ComponentEF ToEF(this ComponentTO Component)
        {
            if (Component is null)
                throw new ArgumentNullException(nameof(Component));

            return new ComponentEF
            {
                Id = Component.Id,
                NameEnglish = Component.Name.English,
                NameFrench = Component.Name.French,
                NameDutch = Component.Name.Dutch
            };
        }

        public static ComponentEF UpdateFromDetached(this ComponentEF AttachedEF, ComponentEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update ComponentEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Room = DetachedEF.Room;
                AttachedEF = AttachedEF.FillFromMultiLanguageString(DetachedEF.ExtractToMultiLanguageString());
            }

            return AttachedEF;
        }
    }
}
