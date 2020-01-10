using OnlineServices.Common.DataAccessHelpers;

namespace OnlineServices.Common.MealServices.TransfertObjects
{
    public class SupplierTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
