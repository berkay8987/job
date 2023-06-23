using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Core.Contexts.Data;
using P1_HangfireProject.Core.Entities.Models;
using P1_HangfireProject.DataAccess.Abstract;

namespace P1_HangfireProject.DataAccess.Concrete
{
    public class ProductServiceDal : IProductServiceDal
    {
        ProjectDbContext _context;

        public ProductServiceDal(ProjectDbContext context)
        {
            _context = context;
        }

        public Product? GetProductByIdDal(int productId)
        {
            return _context.Products
                .Where(x => x.ProductId == productId && x.IsDeleted == 0 && x.IsActive == 1)
                .SingleOrDefault();
        }

        public void SaveChangesDal(Product product, decimal newTryPrice)
        {
            product.PriceTRY = product.PriceUSD*newTryPrice;

            _context.SaveChanges();

            Console.WriteLine($"Changed Price of {product.ProductName} to {product.PriceTRY}");
        }

        public List<Product> GetAllProductsDal()
        {
            return _context.Products.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }
    }
}
