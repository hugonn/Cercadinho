using DataReader.Infra.Data.Sell;
using DataReader.Infra.Storage.DataManager.Lists;

namespace DataReader.Infra.Storage.DataManager
{
    public class Processor
    {
        public ListManager ListManager = new ListManager();

        public List<Item> ProcessItems(string items)
        {
            var processedItems = new List<Item>();

            foreach (var item in items.Split(','))
            {
                var itemSplitted = item.Split('-');
                var obj = new Item
                    (
                        Convert.ToInt32(itemSplitted[0]),
                        Convert.ToInt32(itemSplitted[1]),
                        Convert.ToDecimal(itemSplitted[2].Replace(".", ","))

                    );
                processedItems.Add(obj);
            }
            return processedItems;
        }

        public int TotalOfClients()
        {
            return ListManager.Clients.Count;
        }

        public int TotalOfSalesman()
        {
            return ListManager.Salesmen.Count;
        }

        public int GetIdOfExpansiveSell()
        {
            var result = ListManager.Salesmen
                .SelectMany(t => t.Sales)
                .OrderByDescending(e => e.Items.Select( t=> t.Price).Sum())
                .FirstOrDefault();

            return result.Id;
        }

        public string GetWorstSeller()
        {
            var worstSeller = ListManager.Salesmen
                .OrderBy(x => x.Sales.Select(t => t.Items.Sum(y => y.Price)).Min())
                .FirstOrDefault();

            return worstSeller.Name;
        }
    }
}
