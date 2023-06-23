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

        public Product? GetInactiveProductByNameDal(string productName)
        {
            return _context.Products
                .Where(x => x.ProductName == productName && x.IsActive == 0 && x.IsDeleted == 1)
                .SingleOrDefault();
        }

        public Product? GetProductByNameDal(string productName)
        {
            return _context.Products
                .Where(x => x.ProductName == productName && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public void ReactivateProductDal(Product product)
        {
            product.IsActive = 1;
            product.IsDeleted = 0;
            _context.SaveChanges();
        }

        public void DeactivateProductDal(Product product)
        {
            product.IsActive = 0;
            product.IsDeleted = 1;
            _context.SaveChanges();
        }

        public Product? AddNewProductDal(Product prodcut)
        {
            prodcut.IsActive = 1;
            prodcut.IsDeleted = 0;
            _context.Products.Add(prodcut);
            _context.SaveChanges();
            return prodcut;
        }

        public void IncreaseQuantityOfAProductDal(Product product, int increaseBy)
        {
            product.Quantity += increaseBy;
            _context.SaveChanges();
        }
    }
}
