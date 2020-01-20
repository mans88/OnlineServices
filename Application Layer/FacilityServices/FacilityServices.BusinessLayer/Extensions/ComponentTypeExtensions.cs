using FacilityServices.BusinessLayer.Domain;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Extensions
{
    public static class ComponentTypeExtensions
    {
        public static ComponentType ToDomain(this ComponentTypeTO ComponentTypeTO)
        {
            if (ComponentTypeTO is null)
                throw new NullComponentTypeException(nameof(ComponentTypeTO));

            return new ComponentType()
            {
                Id = ComponentTypeTO.Id,
                Archived = ComponentTypeTO.Archived,
                Name = ComponentTypeTO.Name,
            };
        }
        public static ComponentTypeTO ToTransfertObject(this ComponentType ComponentType)
        {
            if (ComponentType is null)
                throw new NullComponentTypeException(nameof(ComponentType));

            return new ComponentTypeTO()
            {
                Id = ComponentType.Id,
                Archived = ComponentType.Archived,
                Name = ComponentType.Name,
            };
        }
    }
}