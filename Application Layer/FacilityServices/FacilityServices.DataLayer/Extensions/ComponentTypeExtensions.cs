using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;

namespace FacilityServices.DataLayer.Extensions
{
    public static class ComponentTypeExtensions
    {
        public static ComponentTypeTO ToTransfertObject(this ComponentTypeEF componentType)
        {
            if (componentType is null)
                throw new NullComponentTypeException(nameof(componentType));

            return new ComponentTypeTO
            {
                Id = componentType.Id,
                Name = new MultiLanguageString(componentType.NameEnglish, componentType.NameFrench, componentType.NameDutch),
                Archived = componentType.Archived,
                
            };
        }

        public static ComponentTypeEF ToEF(this ComponentTypeTO componentType)
        {
            if (componentType is null)
                throw new NullComponentTypeException(nameof(componentType));

            var componentTypeEf = new ComponentTypeEF
            {
                Id = componentType.Id,
                NameEnglish = componentType.Name.English,
                NameFrench = componentType.Name.French,
                NameDutch = componentType.Name.Dutch,
                Archived = componentType.Archived,
            };

           return componentTypeEf;
            
        }
        public static ComponentTypeEF UpdateFromDetached(this ComponentTypeEF AttachedEF, ComponentTypeEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update ComponentTypeEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Id = DetachedEF.Id;
                AttachedEF.Archived = DetachedEF.Archived;
                AttachedEF = AttachedEF.FillFromMultiLanguageString(DetachedEF.ExtractToMultiLanguageString());

            }
            return AttachedEF;
        }
    }
}
