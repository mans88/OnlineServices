using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public Floor Floor { get; set; }
        public bool Archived { get; set; }
        public IList<ComponentType> ComponentTypes { get; set; }
    }
}
