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
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PutModels;
using RetailStoreWebApi.DataAccess.Concrete;

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

        public ProductGetModel? AddNewProduct(ProductPostModel productPostModel)
        {
            /*
             * 1) Product exists in the db but is inactive -> make it active
             * 2) Product does not exists -> add product
             * 3) Product already exists and active. -> quantity++;
             */

            var productInactive = _productServiceDal.GetInactiveProductByNameDal(productPostModel.ProductName);
            var productActive = _productServiceDal.GetProductByNameDal(productPostModel.ProductName);

            // 1)
            if (productInactive != null)
            {
                _productServiceDal.ReactivateProductDal(productInactive);
                var productGetModel1 = _mapper.Map<ProductGetModel>(productInactive);
                return productGetModel1;
            }

            // 3)
            else if (productActive != null)
            {
                _productServiceDal.IncreaseQuantityOfAProductDal(productActive, 1);
                var productGetModel2 = _mapper.Map<ProductGetModel>(productActive);
                return productGetModel2;
            }

            // 2)
            var productToAdd = _mapper.Map<Product>(productPostModel);
            var newProduct = _productServiceDal.AddNewProductDal(productToAdd);
            var productGetModel = _mapper.Map<ProductGetModel>(newProduct);
            return productGetModel ?? null;
        }

        public ProductGetModel? DeactivateProduct(int productId)
        {
            var product = _productServiceDal.GetProductByIdDal(productId);
            if (product == null) { return null; }
            _productServiceDal.DeactivateProductDal(product);

            var productGetModel = _mapper.Map<ProductGetModel>(product);
            return productGetModel;
        }
    }
}
