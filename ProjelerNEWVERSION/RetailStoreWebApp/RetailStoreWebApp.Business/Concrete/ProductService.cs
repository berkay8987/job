using RetailStoreWebApp.Business.Abstract;
using RetailStoreWebApp.Core.Entities.ViewModels;
using RetailStoreWebApp.DataAccess.Abstract;
using RetailStoreWebApp.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace RetailStoreWebApp.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductServiceDal _productServiceDal;
        private readonly IMapper _mapper;

        public ProductService(
            IProductServiceDal productServiceDal, 
            IMapper mapper)
        {
            _productServiceDal = productServiceDal;
            _mapper = mapper;
        }

        public List<ProductGetModel> GetAllProducts()
        {
            var products = _productServiceDal.GetAllProductsDal();
            var productsGetModel = _mapper.Map<List<Product>, List<ProductGetModel>>(products);
            return productsGetModel;
        }

        public ProductGetModel GetProductById(int id)
        {
            var product = _productServiceDal.GetProductByIdDal(id);
            var productGetModel = _mapper.Map<ProductGetModel>(product);
            return productGetModel;
        }

        public void UpdateProduct(ProductPutModel productPutModel)
        {
            var productToUpdate = _productServiceDal.GetProductByIdDal(productPutModel.ProductId);
            _productServiceDal.UpdateProductDal(productToUpdate, productPutModel.Quantity, productPutModel.PriceUsd);
        }
    }
}
