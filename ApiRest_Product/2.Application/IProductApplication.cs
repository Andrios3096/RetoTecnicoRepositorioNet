using ApiRest_Product._2.Application.DTOs;
using ApiRest_Product._3.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._2.Application
{
    public interface IProductApplication
    {
        Task<string> AddProduct(ProductDTO product);
        Task<string> UpdateProduct(ProductDTO product);
        Task<string> DeleteProduct(Guid guid);
        Task<IEnumerable<ProductDOM>> GetAll();
        Task<ProductDOM> GetProductById(Guid guid);
    }
}
