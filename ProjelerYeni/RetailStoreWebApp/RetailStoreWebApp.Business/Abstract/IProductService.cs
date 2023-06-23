using RetailStoreWebApp.Core.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.Business.Abstract
{
    public interface IProductService
    {
        List<ProductGetModel> GetAllProducts();

        ProductGetModel GetProductById(int id);

        void UpdateProduct(ProductPutModel productPutModel);

        void DeactivateProduct(int id);

        void AddNewProduct(ProductPostModel productPostModel);
    }
}
