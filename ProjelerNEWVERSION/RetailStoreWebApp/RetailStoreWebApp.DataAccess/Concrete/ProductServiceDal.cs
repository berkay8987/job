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

        public Product? GetProductByNameDal(string productName)
        {
            return _context.Products
                .Where(x => x.ProductName == productName && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public Product? GetInactiveProductByNameDal(string productName)
        {
            return _context.Products
                .Where(x => x.ProductName == productName && x.IsActive == 0 && x.IsDeleted == 1)
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

        public void DeactivateProductDal(Product product)
        {
            product.IsActive = 0;
            product.IsDeleted = 1;
            _context.SaveChanges();
        }

        public void ReactivateProductDal(Product product)
        {
            product.IsActive = 1;
            product.IsDeleted = 0;
            _context.SaveChanges();
        }

        public void AddNewProductDal(Product product)
        {
            product.IsActive = 1;
            product.IsDeleted = 0;
            product.PriceTry = product.PriceUsd * _context.Rates.Where(x => x.RatesId == 1).SingleOrDefault().Try;
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
