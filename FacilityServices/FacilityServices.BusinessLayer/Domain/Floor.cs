namespace FacilityServices.BusinessLayer.Domain
{
    public class Floor
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Archived { get; set; }
        //public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
