using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.Common.FacilityServices.TransfertObjects
{
    public class RoomTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public FloorTO Floor { get; set; }
    }
}
