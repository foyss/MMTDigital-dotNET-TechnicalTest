using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSETechnicalTest.API.Interfaces;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SSETechnicalTest.API.Controllers
{
    /// <summary>
    /// Products controller used to manage product resources
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDbServices _dbServices;

        public ProductsController(IDbServices dbServices)
        {
            _dbServices = dbServices;
        }

        /// <summary>
        /// Retrieve a list of featured products within the MMT Shop
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetFeaturedProducts()
        {
            try
            {
                var featuredProducts = await _dbServices.GetFeaturedProductsAsync();

                return StatusCode(200, featuredProducts);
            }
            catch (SqlException se)
            {
#if DEBUG
                return StatusCode(400, se);
#else
                return StatusCode(400, $"A sql related error has occurred while attempting to get featured products");
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500, $"A generic exception was caught while attempting to retrieve featured products");
#endif
            }
        }

        /// <summary>
        /// Retrieve a list of available categories
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAvailableCategories()
        {
            try
            {
                var availableCategories = await _dbServices.GetAvailableCategoryNamesAsync();

                return StatusCode(200, availableCategories);
            }
            catch (SqlException se)
            {
#if DEBUG
                return StatusCode(400, se);
#else
                return StatusCode(400, $"A sql related error has occurred while attempting to get available categories");
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500, $"A generic exception was caught while attempting to get available categories");
#endif
            }
        }

        /// <summary>
        /// Retrieve a list of products based on the category specified
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{categoryName}")]
        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            try
            {
                var productsByCategory = await _dbServices.GetProductsByCategoryAsync(categoryName);

                return StatusCode(200, productsByCategory);
            }
            catch (SqlException se)
            {
                if (se.Number == 50000 && se.Message.StartsWith($"Category"))
                    return StatusCode(400, $"Invalid Category Name provided");

#if DEBUG
                return StatusCode(400, se);
#else
                return StatusCode(400, $"A sql related error has occurred while attempting to get products by category");
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500, $"A generic exception was caught while attempting to get products by category");
#endif
            }
        }
    }
}
