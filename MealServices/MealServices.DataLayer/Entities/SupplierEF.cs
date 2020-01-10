using OnlineServices.Common.DataAccessHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealServices.DataLayer.Entities
{
    [Table("Suppliers")]
    public class SupplierEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public ICollection<MealEF> Meals { get; set; }
    }
}
