using ApiRest_Product._2.Application.DTOs;
using ApiRest_Product._3.Persistence;
using ApiRest_Product._3.Persistence.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._2.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository,
             IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<string> AddProduct(ProductDTO product)
        {
            var result = await _productRepository.AddProduct(product);
            return result;
        }

        public async Task<string> DeleteProduct(Guid guid)
        {
            return await _productRepository.DeleteProductAsync(guid);
        }

        public async Task<string> UpdateProduct(ProductDTO product)
        {
            var entity = _mapper.Map<ProductDOM>(product);
            var result = await _productRepository.UpdateProduct(product.Id, entity);
            return result;
        }
        public async Task<IEnumerable<ProductDOM>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<ProductDOM> GetProductById(Guid guid)
        {
            return await _productRepository.GetProductById(guid);
        }
    }
}
