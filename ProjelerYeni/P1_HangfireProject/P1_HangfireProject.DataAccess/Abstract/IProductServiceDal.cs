using P1_HangfireProject.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_HangfireProject.DataAccess.Abstract
{
    public interface IProductServiceDal
    {
        List<Product> GetAllProductsDal();

        Product? GetProductByIdDal(int productId);

        void SaveChangesDal(Product product, decimal newTryPrice);
    }
}
