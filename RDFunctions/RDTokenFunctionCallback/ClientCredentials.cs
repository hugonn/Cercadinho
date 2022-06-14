using System;
using System.Collections.Generic;
using System.Text;

namespace RDTokenFunctionCallback
{
    public class ClientCredentials
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string code { get; set; }

        public ClientCredentials(string code)
        {
            client_id = "{Client_Id_From_RDStation}";
            client_secret = "{Client_Secret_From_RDStation}";
            this.code = code;
        }
    }
}
