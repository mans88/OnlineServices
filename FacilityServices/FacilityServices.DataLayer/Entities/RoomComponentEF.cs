using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityServices.DataLayer.Entities
{
    [Table("RoomComponents")]
    public class RoomComponentEF
    {
        public int ComponentTypeId { get; set; }
        public ComponentTypeEF ComponentType { get; set; }

        public int RoomId { get; set; }
        public RoomEF Room { get; set; }
    }
}
