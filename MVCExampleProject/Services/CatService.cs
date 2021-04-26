using MVCExampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCExampleProject.Services
{
    public class CatService : ICatService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _baseUrl;

        public CatService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _baseUrl = "https://thatcopy.pw/catapi/";
        }

        public async Task<CatResponse> GetRandomCat()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + "rest/");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // deserialize json and return
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return JsonSerializer.DeserializeAsync<CatResponse>(responseStream).Result;
            }
            else
            {
                throw new Exception("I broke it");
            }
        }
    }
}
