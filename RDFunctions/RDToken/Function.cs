using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDToken
{
    public class Function : IHttpFunction
    {
        private string _url = "https://api.rd.services/auth/dialog?";
        private Client _client = new Client();
        private HttpClient _httpClient = new HttpClient();

        public async Task HandleAsync(HttpContext context)
        {
            _url += $"client_id={_client.ClientId}&redirect_uri={_client.RedirecrUri}";
            await CallTokenFunction();
        }

        public async Task CallTokenFunction()
        {
            var result = await _httpClient.GetStringAsync(_url);
            System.Console.WriteLine("");
        }
    }
}
