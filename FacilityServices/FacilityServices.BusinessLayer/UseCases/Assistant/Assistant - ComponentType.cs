using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ComponentTypeTO UpdateComponentType(ComponentTypeTO componentTypeToUpdate)
        {
            if (componentTypeToUpdate is null)
            {
                throw new ArgumentNullException("The ComponentType object cannot be null !");
            }

            if (componentTypeToUpdate.Id <= 0)
            {
                throw new LoggedException("The ComponentType object cannot be updated without it's ID");
            }

            return unitOfWork.ComponentTypeRepository.Update(componentTypeToUpdate);
        }

        public bool RemoveComponentType(int componentTypeId)
        {
            if (componentTypeId <= 0)
            {
                throw new LoggedException("The ComponentType ID is not in the correct format ! An integer in required.");
            }

            if (!unitOfWork.ComponentTypeRepository.GetAll().Any(x => x.Id == componentTypeId))
            {
                throw new KeyNotFoundException("No ComponentType was found for the given ID!");
            }

            return unitOfWork.ComponentTypeRepository.Remove(componentTypeId);
        }
    }
}