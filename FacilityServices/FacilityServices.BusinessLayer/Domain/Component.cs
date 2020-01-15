using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace FacilityServices.BusinessLayer
{
    public class Component
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public MultiLanguageString Name { get; set; }

        public Component (MultiLanguageString name)
        {
            this.Name = name;
        }

    }
}
