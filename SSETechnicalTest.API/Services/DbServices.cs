using Dapper;
using Microsoft.Extensions.Configuration;
using SSETechnicalTest.API.Constants;
using SSETechnicalTest.API.Dapper;
using SSETechnicalTest.API.Interfaces;
using SSETechnicalTest.API.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SSETechnicalTest.API.Services
{
    /// <summary>
    /// DbServices class used to connect to SQL database and retrieve requested resources
    /// </summary>
    public class DbServices : IDbServices
    {
        private readonly IConfiguration _configuration;

        public DbServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ProductsModel>> GetFeaturedProductsAsync()
        {
            using var dbConnection = await new MmtSqlConnectionFactory(_configuration).CreateConnectionAsync();

            var sqlParams = new
            {
                Featured = true
            };

            var featuredProducts = await dbConnection.QueryAsync<ProductsModel>(SqlCommands.SpGetProducts, sqlParams, commandType: CommandType.StoredProcedure);

            return featuredProducts.ToList();
        }

        public async Task<List<string>> GetAvailableCategoryNamesAsync()
        {
            using var dbConnection = await new MmtSqlConnectionFactory(_configuration).CreateConnectionAsync();

            var availableCategories = await dbConnection.QueryAsync<string>(SqlCommands.SpGetAvailableCategories, commandType: CommandType.StoredProcedure);

            return availableCategories.ToList();
        }

        public async Task<List<ProductsModel>> GetProductsByCategoryAsync(string categoryName)
        {
            using var dbConnection = await new MmtSqlConnectionFactory(_configuration).CreateConnectionAsync();

            var sqlParams = new
            {
                CategoryName = categoryName
            };

            var availableProducts = await dbConnection.QueryAsync<ProductsModel>(SqlCommands.SpGetProducts, sqlParams, commandType: CommandType.StoredProcedure);

            return availableProducts.ToList();
        }
    }
}
