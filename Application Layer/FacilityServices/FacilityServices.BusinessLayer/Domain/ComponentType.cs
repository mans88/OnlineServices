using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Domain
{
    public class ComponentType
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool Archived { get; set; }
    }
}
