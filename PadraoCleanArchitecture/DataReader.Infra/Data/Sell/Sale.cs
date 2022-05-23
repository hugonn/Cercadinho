
namespace DataReader.Infra.Data.Sell
{
    public class Sale
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }   
        public string SellerName { get; set; }
            
        public Sale(int id, List<Item> items, string sellerName) 
        {
            Id = id;
            Items = items;
            SellerName = sellerName;
        }
        
        public decimal GetExpansivePriceItem()
        {
            return Items.Max(x => x.Price);
        }

        public decimal GetSumOfSells()
        {
            return Items.Sum(x => x.Price);
        }
    }
}
