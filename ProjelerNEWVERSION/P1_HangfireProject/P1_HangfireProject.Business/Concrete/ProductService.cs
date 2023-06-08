using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.DataAccess.Abstract;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.Core.Entities.Models;
using Microsoft.IdentityModel.Logging;

namespace P1_HangfireProject.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductServiceDal _productServiceDal;

        public ProductService(IProductServiceDal productServiceDal)
        {
            _productServiceDal = productServiceDal;
        }

        public Product? GetProductById(int productId)
        {
            return _productServiceDal.GetProductByIdDal(productId) ?? null;
        }

        public List<Product>? GetAllProducts()
        {
            return _productServiceDal.GetAllProductsDal() ?? null;
        }

        public void SaveChanges(decimal _try, List<Product> products)
        {
            if (products == null)
            {
                return;
            }

            foreach (var item in products)
            {
                _productServiceDal.SaveChangesDal(item, _try);
            }
        }
    }
}
