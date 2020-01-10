using OnlineServices.Common.DataAccessHelpers;

namespace OnlineServices.Common.FacilityServices.TransfertObjects
{
    public class FloorTO : IEntity<int>
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
