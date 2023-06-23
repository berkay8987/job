using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;

namespace RetailStoreWebApi.Business.Abstract
{
    public interface IProductService
    {
        List<ProductGetModel>? GetAllProducts();

        ProductGetModel? GetProductById(int productId);

        ProductGetModel? UpdateProduct(int productId, int quantity, decimal priceUsd);

        ProductGetModel? AddNewProduct(ProductPostModel productPostModel);

        ProductGetModel? DeactivateProduct(int productId);
    }
}
