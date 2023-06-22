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

        void UpdateProductDal(Product product, int quantity, decimal priceUsd);
    }
}
