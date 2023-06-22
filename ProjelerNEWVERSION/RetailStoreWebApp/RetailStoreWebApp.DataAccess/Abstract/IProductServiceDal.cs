using RetailStoreWebApp.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.DataAccess.Abstract
{
    public interface IProductServiceDal
    {
        List<Product> GetAllProductsDal();

        Product? GetProductByIdDal(int id);

        Product? GetProductByNameDal(string productName);

        Product? GetInactiveProductByNameDal(string productName);

        void UpdateProductDal(Product product, int quantity, decimal priceUsd);

        void DeactivateProductDal(Product product);

        void ReactivateProductDal(Product product);

        void AddNewProductDal(Product product);
    }
}
