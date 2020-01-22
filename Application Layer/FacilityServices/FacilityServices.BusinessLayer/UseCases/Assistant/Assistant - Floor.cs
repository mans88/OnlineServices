using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public FloorTO AddFloor(FloorTO floorToAdd)
        {
            if (floorToAdd is null)
            {
                throw new System.ArgumentNullException(nameof(floorToAdd));
            }

            return unitOfWork.FloorRepository.Add(floorToAdd);
        }

        public bool RemoveFloor(int floorId)
        {
            if (floorId <= 0)
            {
                throw new LoggedException("The Floor's ID is not in the correct format ! An integer in required.");
            }

            var floor = unitOfWork.FloorRepository.GetById(floorId);

            if (floor is null)
            {
                throw new KeyNotFoundException("No Floor was found for the given ID!");
            }
            floor.Archived = true;
            var result = unitOfWork.FloorRepository.Update(floor);

            return result.Archived == true;
        }
        public FloorTO UpdateFloor(FloorTO floorToUpdate)
        {
            if (floorToUpdate is null)
            {
                throw new ArgumentNullException("The ComponentType object cannot be null !");
            }

            if (floorToUpdate.Id <= 0)
            {
                throw new LoggedException("The Floor object cannot be updated without it's ID");
            }

            return unitOfWork.FloorRepository.Update(floorToUpdate);
        }
    }
}