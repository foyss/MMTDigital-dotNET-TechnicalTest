using RestSharp;
using System;
using System.Threading.Tasks;

namespace SSETechnicalTest.ConsoleApp
{
    class Program
    {
        private static RestClient _httpClient;

        static async Task Main(string[] args)
        {
            Console.WriteLine("SSE Tech Test Console Application by Foysal");
            Console.WriteLine(Environment.NewLine);

            _httpClient = new RestClient("https://localhost:44313");

            Console.WriteLine("=== Featured Products ===");

            var featuredProductsRequest = new RestRequest("Products/GetFeaturedProducts", Method.GET);
            var featuredProductsResult = _httpClient.Execute(featuredProductsRequest);

            Console.WriteLine("=== RESULTS ===");
            Console.Write($"{featuredProductsResult.Content}");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("=== Available Categories ===");

            var availableCategoriesRequest = new RestRequest("Products/GetAvailableCategories", Method.GET);
            var availableCategoriesResult = _httpClient.Execute(availableCategoriesRequest);

            Console.WriteLine("=== RESULTS ===");
            Console.Write($"{availableCategoriesResult.Content}");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("=== Products by Category ===");

            var categoryName = default(string);
            Console.WriteLine("=== Please enter a category to search ===");

            categoryName = Console.ReadLine();

            var productsByCategoryRequest = new RestRequest($"Products/GetProductsByCategory/{categoryName}", Method.GET);
            var productsByCategoryResult = _httpClient.Execute(productsByCategoryRequest);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("=== RESULTS ===");
            Console.Write($"{productsByCategoryResult.Content}");


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
