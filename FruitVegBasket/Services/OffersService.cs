using FruitVegBasket.Constants;
using FruitVegBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FruitVegBasket.Services
{
    public class OffersService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OffersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);

            var response = await httpClient.GetAsync("/masters/offers");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    return JsonSerializer.Deserialize<IEnumerable<Offer>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }
            return Enumerable.Empty<Offer>();
        }
    }
}
