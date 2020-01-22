using OnlineServices.Common.DataAccessHelpers;

namespace OnlineServices.Common.FacilityServices.TransfertObjects
{
    public class FloorTO : IEntity<int>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Archived { get; set; }
        //public List<RoomTO> Rooms { get; set; } = new List<RoomTO>();
    }
}
