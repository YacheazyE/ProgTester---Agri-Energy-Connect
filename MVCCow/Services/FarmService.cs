using Microsoft.AspNetCore.Mvc;
using MVCCow.Models;
using MVCFarming.Controllers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MVCCow.Services
{
    public class FarmService
    {
        private readonly HttpClient _httpClient;

        public FarmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Farm>> GetAllFarmsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://api-farm-service:8080/api/farm");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new Exception("Response content is empty");
                }

                return JsonConvert.DeserializeObject<List<Farm>>(content) ?? new List<Farm>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occurred while fetching cows from the API.", ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                throw new Exception("An error occurred while deserializing the response.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }


        }
    }
}
