using SSETechnicalTest.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSETechnicalTest.API.Interfaces
{
    public interface IDbServices
    {
        Task<List<ProductsModel>> GetFeaturedProductsAsync();
        Task<List<string>> GetAvailableCategoryNamesAsync();
        Task<List<ProductsModel>> GetProductsByCategoryAsync(string categoryName);

    }
}