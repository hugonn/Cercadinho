using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RDToBigQueryFunction
{
    public class Function : IHttpFunction
    {
        private string url = "https://plugcrm.net/api/v1/contacts?token=6177013a377999001a54d9a8";
        private HttpClient _httpClient = new HttpClient();

        public async Task HandleAsync(HttpContext context)
        {
            await GetContactsFromRD();
        }

        public async Task GetContactsFromRD()
        {
            var result = await _httpClient.GetStringAsync(url);
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            Console.WriteLine(json);
        }
    }
}