using OnlineServices.Common.Extensions;

namespace MealServices.BusinessLayer.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCurrentSupplier { get; set; }

        public bool IsValid()
        {
            Name.IsNullOrWhiteSpace("Supplier Name should not null or empty or whitespace");

            return true;
        }
    }
}
