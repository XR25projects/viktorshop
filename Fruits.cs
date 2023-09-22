namespace Viktors
{
    public class Fruits : Item
    {
        public string Type { get; set; }

        public Fruits(string name, decimal price, int quantity, string brand, string type)
            : base(name, price, quantity, brand)
        {
            Type = type;
        }
    }
}
