using MealServices.BusinessLayer.Domain;

using OnlineServices.Common.MealServices.TransfertObjects;

using System;

namespace MealServices.BusinessLayer.Extensions
{
    public static class SupplierExtensions
    {
        public static Supplier ToDomain(this SupplierTO SupplierTO)
        {
            try
            {
                var SupplierDomain = new Supplier()
                {
                    Id = SupplierTO.Id,
                    Name = SupplierTO.Name,
                    IsCurrentSupplier = SupplierTO.IsDefault
                };

                SupplierDomain.IsValid();

                return SupplierDomain;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SupplierTO ToTransfertObject(this Supplier Supplier)
        {
            return new SupplierTO
            {
                Id = Supplier.Id,
                Name = Supplier.Name,
                IsDefault = Supplier.IsCurrentSupplier
            };
        }
    }
}
