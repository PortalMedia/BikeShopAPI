namespace BikeShopAPI.Models
{
    public class Bicycle
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public Customer Owner { get; set;  }
    }
}