using P1_HangfireProject.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_HangfireProject.Business.Abstract
{
    public interface IProductService
    {
        List<Product>? GetAllProducts();

        Product? GetProductById(int productId);

        void SaveChanges(decimal _try, List<Product> products);
    }
}
