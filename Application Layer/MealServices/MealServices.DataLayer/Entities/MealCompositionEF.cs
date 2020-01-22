using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MealServices.DataLayer.Entities
{
    [Table("MealCompositions")]
    public class MealCompositionEF : IEquatable<MealCompositionEF>
    {
        public int MealId { get; set; }

        [ForeignKey("MealId")]
        public MealEF Meal { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public IngredientEF Ingredient { get; set; }

        public bool IsValid()
            => (this.Meal.Id == this.MealId) && (this.Ingredient.Id == this.IngredientId);

        public bool Equals([AllowNull] MealCompositionEF other)
        {
            if (other is null)
            {
                if (this is null) return true;
                else return false;
            }

            return (this.IsValid() && other.IsValid())
                && (this.IngredientId == other.IngredientId)
                && (this.MealId == other.MealId);
        }

        public override bool Equals(object obj)
            => this.Equals((MealCompositionEF)obj);
    }
}
