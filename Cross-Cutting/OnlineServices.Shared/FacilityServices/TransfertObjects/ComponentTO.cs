using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.Common.FacilityServices.TransfertObjects
{
    public class ComponentTO : IEntity<int>
    {
        public int Id { get; set; }
        public RoomTO Room { get; set; }
        public MultiLanguageString Name { get; set; }
    }
}
