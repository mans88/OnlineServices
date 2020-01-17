using OnlineServices.Common.DataAccessHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityServices.DataLayer.Entities
{
    [Table("Floors")]
    public class FloorEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Archived { get; set; }

        //public IList<RoomEF> Rooms { get; set; }
    }
}
