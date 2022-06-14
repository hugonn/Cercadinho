using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RDTokenFunctionCallback
{
    public class Function : IHttpFunction
    {
        private ClientCredentials _clientCredentials;
        private TokenInformations _tokenInformations;
        private HttpClient _httpClient = new HttpClient();
        private string _tokenURI = "https://api.rd.services/auth/token";
        private string _RDStationAPIFunctionURI = "https://api.rd.services/platform/segmentations"; // in this case, segmentations
        private string _googleCloudProjectId = "{Project_Id}";

        public async Task HandleAsync(HttpContext context)
        {
            var code = context.Request.Query["code"];
            _clientCredentials = new ClientCredentials(code);

            await GetToken();

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _tokenInformations.access_token);

            await InsertJsonIntoBigQuery();
        }
        private async Task GetToken()
        {
            var json = JsonConvert.SerializeObject(_clientCredentials);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_tokenURI, data);
            var content = await response.Content.ReadAsStringAsync();

            _tokenInformations = JsonConvert.DeserializeObject<TokenInformations>(content);
        }
        public async Task InsertJsonIntoBigQuery()
        {
            var credential = GoogleCredential.GetApplicationDefault();
            BigQueryClient client = BigQueryClient.Create(_googleCloudProjectId);
            BigQueryDataset dataset = client.GetOrCreateDataset("{Dataset Name}");
            BigQueryTable table = dataset.GetOrCreateTable("{Table Name}", new TableSchemaBuilder
            {
                { "JSON", BigQueryDbType.String },
            }.Build());

            var segmentations = await GetInformationsFromRDStation();

            table.InsertRow(new BigQueryInsertRow
            {
                { "JSON", segmentations},
            });
        }
        private async Task<string> GetInformationsFromRDStation()
        {
            var response = await _httpClient.GetAsync(_RDStationAPIFunctionURI);

            return JsonConvert.SerializeObject(response);
        }
    }
} 
