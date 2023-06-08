using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.Models;

namespace RetailStoreWebApi.DataAccess.Abstract
{
    public interface IProductServiceDal
    {
        List<Product>? GetAllProductsDal();

        Product? GetProductByIdDal(int productId);

        Product? UpdateProductDal(int quantity, decimal priceUsd, Product product);

        void UpdatePriceProductDal(Product product);
    }
}
