using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace FacilityServices.BusinessLayer
{
    public class Issue
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public MultiLanguageString Name { get; set; }
        
        public Issue(MultiLanguageString name)
        {
            this.Name = name;
        }
    }
}
