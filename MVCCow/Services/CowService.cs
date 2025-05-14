using Microsoft.AspNetCore.Mvc;
using MVCCow.Models;
using MVCFarming.Controllers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MVCCow.Services
{
    public class CowService
    {
        private readonly HttpClient _httpClient;

        public CowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cow>> GetAllCowsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://api-service:8080/api/cow");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new Exception("Response content is empty");
                }

                return JsonConvert.DeserializeObject<List<Cow>>(content) ?? new List<Cow>();
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
