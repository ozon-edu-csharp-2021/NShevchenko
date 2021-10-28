using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<List<SkuResponse>> V1GetByEmployee(long id, CancellationToken token);
        Task<bool> V1TakeMerch(SkuPostViewModel postViewModel, long id, CancellationToken token);
    }

    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SkuResponse>> V1GetByEmployee(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/{id.ToString()}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<SkuResponse>>(body);
        }

        public async Task<bool> V1TakeMerch(SkuPostViewModel postViewModel, long id, CancellationToken token)
        {
            var jsonString = JsonSerializer.Serialize(postViewModel);
            using var response = await _httpClient.PostAsync($"v1/api/merch/{id.ToString()}",
                new StringContent(jsonString, Encoding.UTF8, "application/json"),
                token);
            return response.IsSuccessStatusCode;
        }
    }
}