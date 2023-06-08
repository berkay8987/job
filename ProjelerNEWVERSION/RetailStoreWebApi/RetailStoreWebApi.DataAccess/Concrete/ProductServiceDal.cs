using RetailStoreWebApi.Core.Contexts.Data;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.DataAccess.Concrete
{
    public class ProductServiceDal : IProductServiceDal
    {
        private readonly ProjectDatabaseContext _context;

        public ProductServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<Product>? GetAllProductsDal()
        {
            return _context.Products.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }

        public Product? GetProductByIdDal(int productId)
        {
            return _context.Products
                .Where(x => x.ProductId == productId && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public Product? UpdateProductDal(int quantity, decimal priceUsd, Product product)
        {
            product.Quantity = quantity;
            product.PriceUsd = priceUsd;
            _context.SaveChanges();
            return product;
        }

        public void UpdatePriceProductDal(Product product)
        {
            var _try = _context.Rates.Where(x => x.RatesId == 1).Single().Try;
            product.PriceTry = product.PriceUsd * _try;
            _context.SaveChanges();
        }
    }
}
