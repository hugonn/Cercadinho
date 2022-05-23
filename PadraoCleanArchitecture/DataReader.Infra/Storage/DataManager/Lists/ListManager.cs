using DataReader.Infra.Data.People;
using DataReader.Infra.Data.Sell;

namespace DataReader.Infra.Storage.DataManager.Lists
{
    public class ListManager
    {
        public List<Client> Clients { get; set; }
        public List<Salesman> Salesmen { get; set; }
        public Processor Processor { get; set; }

        public ListManager()
        {
            Clients = new List<Client>();
            Salesmen = new List<Salesman>();
        }
    }
}
