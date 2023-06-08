using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.DataAccess.Abstract;
using RetailStoreWebApi.Core.Entities.Models;
using AutoMapper;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;

namespace RetailStoreWebApi.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductServiceDal _productServiceDal;

        public ProductService(
            IMapper mapper,
            IProductServiceDal productServiceDal)
        {
            _mapper = mapper;
            _productServiceDal = productServiceDal;
        }

        public List<ProductGetModel>? GetAllProducts()
        {
            var products = _productServiceDal.GetAllProductsDal();
            var productsGetModel = _mapper.Map<List<Product>, List<ProductGetModel>>(products);
            return productsGetModel ?? null;
        }

        public ProductGetModel? GetProductById(int productId)
        {
            var product = _productServiceDal.GetProductByIdDal(productId);
            var productGetModel = _mapper.Map<ProductGetModel>(product);
            return productGetModel ?? null;
        }

        public ProductGetModel? UpdateProduct(int productId, int quantity, decimal priceUsd)
        {
            var existingProduct = _productServiceDal.GetProductByIdDal(productId);
            if (existingProduct == null)
            {
                return null;
            }
            var newProduct = _productServiceDal.UpdateProductDal(quantity, priceUsd, existingProduct);
            _productServiceDal.UpdatePriceProductDal(newProduct);
            var newProductGetModel = _mapper.Map<ProductGetModel>(newProduct);
            return newProductGetModel;
        }
    }
}
