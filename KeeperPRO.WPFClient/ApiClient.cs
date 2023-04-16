using KeeperPRO.Api.Common.Exeptions;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace KeeperPRO.WPFClient
{
    public class ApiClient
    {
        public static async Task<T> GetEntityAsync<T>(
            string requestUri, 
            string baseAddress = "https://localhost:7170")
        {
            var response = await InitializeHttpClient(baseAddress)
                .GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result ?? throw new NotFoundExeption<T>();
            }
            throw new NullReferenceException(response.StatusCode.ToString());
        }

        public static async Task<IEnumerable<T>> GetAllEntitysAsync<T>(
            string requestUri, 
            string baseAddress = "https://localhost:7170")
        {
            var response = await InitializeHttpClient(baseAddress)
                .GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
                return result ?? throw new NotFoundExeption<IEnumerable<T>>();
            }
            throw new NullReferenceException(response.StatusCode.ToString());
        }

        private static HttpClient InitializeHttpClient(
            string baseAddress,
            string mediaType = "application/json")
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));
            return httpClient;
        }
    }
}
