

using System.Net.Http;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task GetProducts()
        {
            Console.WriteLine("GetProducts called");
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
            if (result != null && result.Data != null)
                Products = result.Data;
            Console.WriteLine($"Products: {Products.Count}");

        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            Console.WriteLine("GetProduct called");
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
            //Console.WriteLine($"Product: {result.Data}");
            return result;
        }

    }
}
