using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.Domain
{
    public class Issue
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool Archived { get; set; }
        public ComponentType ComponentType { get; set; }

        public Issue(MultiLanguageString name)
        {
            this.Name = name;
        }
    }
}
