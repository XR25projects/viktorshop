namespace Viktors
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }

        public Item(string name, decimal price, int quantity, string brand)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Brand = brand;
        }
    }
}
