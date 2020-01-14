using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public ComponentTypeTO AddComponentType(ComponentTypeTO componentTypeToAdd)
        {
            if (componentTypeToAdd is null)
            {
                throw new ArgumentNullException(nameof(componentTypeToAdd));
            }

            return unitOfWork.ComponentTypeRepository.Add(componentTypeToAdd);
        }
    }
}
