using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDApiToBigQuery
{
    public class Function : IHttpFunction
    {
        private string _url = "{rdStation_URL}";
        private HttpClient _httpClient = new HttpClient();
        private string _googleCloudProjectId = "{project_id}";

        public async Task HandleAsync(HttpContext context)
        {
            await InsertJsonIntoBigQuery();
        }
        public async Task InsertJsonIntoBigQuery()
        {
            var credential = GoogleCredential.GetApplicationDefault();
            BigQueryClient client = BigQueryClient.Create(_googleCloudProjectId);
            BigQueryDataset dataset = client.GetOrCreateDataset("{DataSet Name}");
            BigQueryTable table = dataset.GetOrCreateTable("{Table Name}", new TableSchemaBuilder
            {
                { "{Column}", BigQueryDbType.String },
            }.Build());

            var json = await GetContactsFromRD();

            table.InsertRow(new BigQueryInsertRow
            {
                { "{Column}", json},
            });
        }
        public async Task<string> GetContactsFromRD()
        {
            var result = await _httpClient.GetStringAsync(_url);
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }
    }
}

