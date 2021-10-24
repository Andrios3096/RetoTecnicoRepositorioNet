using ApiRest_Product._2.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._3.Persistence.Repository
{
    public interface IProductRepository
    {
        Task<string> AddProduct(ProductDTO product);
        Task<string> UpdateProduct(Guid guid, ProductDOM product);
        Task<IEnumerable<ProductDOM>> GetAllAsync();
        Task<ProductDOM> GetProductById(Guid guid);
        Task<string> DeleteProductAsync(Guid guid);
    }
}
