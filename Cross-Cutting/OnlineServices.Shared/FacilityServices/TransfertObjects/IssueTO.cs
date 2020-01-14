using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.Common.FacilityServices.TransfertObjects
{
    public class IssueTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool Archived { get; set; }
        public ComponentTypeTO ComponentType { get; set; }
    }
}
