using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDToBigQueryFunction
{
    public class Function : IHttpFunction
    {
        private string url = "{rdStation_URL}";
        private HttpClient _httpClient = new HttpClient();
        private string _projectId = "{project_id}";

        public async Task HandleAsync(HttpContext context)
        {
            await InsertJsonIntoBigQuery();
        }

        public async Task InsertJsonIntoBigQuery()
        {
            var credential = GoogleCredential.GetApplicationDefault();
            BigQueryClient client = BigQueryClient.Create(_projectId);
            BigQueryDataset dataset = client.GetOrCreateDataset("DataSet_Test");
            BigQueryTable table = dataset.GetOrCreateTable("Table_Test", new TableSchemaBuilder
            {
                { "JsonColumn", BigQueryDbType.String },
            }.Build());

            var json = await GetContactsFromRD();

            table.InsertRow(new BigQueryInsertRow
            {
                { "JsonColumn", json},
            });
        }
        public async Task<string> GetContactsFromRD()
        {
            var result = await _httpClient.GetStringAsync(url);
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }
    }
}