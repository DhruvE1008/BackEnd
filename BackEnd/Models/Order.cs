namespace IceCreamStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ItemType { get; set; }
        public string Flavor { get; set; } 
        public int Quantity { get; set; }
    }
}