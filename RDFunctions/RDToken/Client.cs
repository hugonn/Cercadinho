
using Microsoft.Extensions.Configuration;

namespace RDToken
{
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirecrUri { get; set; }

        public Client()
        {
            ClientId = "a6f64981-0679-45b8-9d5b-a399a40a463f";
            ClientSecret = "1d09188f4dde4f1396c1d0f0ff7611ef";
            RedirecrUri = "http://127.0.0.1:8080";
        }
    }
}
