using RetailStoreWebApp.Core.Contexts.Data;
using RetailStoreWebApp.Core.Entities.Models;
using RetailStoreWebApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.DataAccess.Concrete
{
    public class ProductServiceDal : IProductServiceDal
    {
        private readonly ProjectDatabaseContext _context;

        public ProductServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProductsDal()
        {
            return _context.Products.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }

        public Product? GetProductByIdDal(int id)
        {
            return _context.Products
                .Where(x => x.ProductId == id && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public void UpdateProductDal(Product product, int quantity, decimal priceUsd)
        {
            var rateTry = _context.Rates.Where(x => x.RatesId == 1).SingleOrDefault().Try;
            product.Quantity = quantity;
            product.PriceUsd = priceUsd;
            product.PriceTry = priceUsd * rateTry;
            _context.SaveChanges();
        }
    }
}
