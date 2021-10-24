using ApiRest_Product._2.Application.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._3.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            connectionString = @"Server=.;Database=Project_reto_tecnico;Integrated Security=True;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public async Task<string> AddProduct(ProductDTO product)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductName", product.cProductName);
                    parameters.Add("@Price", product.nPrice);
                    parameters.Add("@Stock", product.nStock);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<ProductDOM>(
                        "dbo.ProductCreate",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                    {
                        return "201 CREATED";
                    }
                    else
                    {
                        return "500 INTERNAL SERVER ERROR";
                    }

                }
            }
            catch (Exception ex)
            {
                return "500 INTERNAL SERVER ERROR";
            }
        }

        public async Task<string> DeleteProductAsync(Guid guid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", guid);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<ProductDOM>(
                        "dbo.ProductDelete",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                    {
                        return "201 CREATED";
                    }
                    else
                    {
                        return "500 INTERNAL SERVER ERROR";
                    }
                }
            }
            catch (Exception ex)
            {
                return "500 INTERNAL SERVER ERROR";
            }
        }

        public async Task<IEnumerable<ProductDOM>> GetAllAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<ProductDOM>(
                        "dbo.ProductGetAll",
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return excute;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<ProductDOM> GetProductById(Guid guid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", guid);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryFirstAsync<ProductDOM>(
                        "dbo.ProductGetById",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return excute;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<string> UpdateProduct(Guid guid, ProductDOM product)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", guid);
                    parameters.Add("@ProductName", product.cProductName);
                    parameters.Add("@Price", product.nPrice);
                    parameters.Add("@Stock", product.nStock);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<ProductDOM>(
                        "dbo.ProductUpdate",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                    {
                        return "201 CREATED";
                    }
                    else
                    {
                        return "500 INTERNAL SERVER ERROR";
                    }
                }
            }
            catch (Exception ex)
            {
                return "500 INTERNAL SERVER ERROR";
            }
        }
    }
}
