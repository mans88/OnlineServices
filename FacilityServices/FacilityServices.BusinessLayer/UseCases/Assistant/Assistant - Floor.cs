using OnlineServices.Common.FacilityServices.TransfertObjects;

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
            throw new System.NotImplementedException();
        }
        public FloorTO UpdateFloor(FloorTO floorToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}