using System;
using System.Collections.Generic;
using System.Linq;

namespace Viktors
{
    public class Store
    {
        private List<Item> items;

        public Store()
        {
            items = new List<Item>
            {
                new Item("Bananas", 5.0m, 10, "Tropical"),
                new Item("Apples", 4.0m, 15, "Red Delicious"),
                new Item("Toilet Paper", 30.0m, 50, "Really Soft"),
                new Item("Cigarettes", 60.0m, 20, "Marlboro"),
                new Item("Snus", 40.0m, 25, "Odens Strong")
            };
        }

        public void DisplayItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - {item.Price} kr - Quantity: {item.Quantity} - Brand: {item.Brand}");
            }
        }

        public bool HasItem(string itemName)
        {
            return items.Any(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase) && item.Quantity > 0);
        }

        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public void DeductQuantity(Item item, int quantity)
        {
            if (item != null)
            {
                var storeItem = items.FirstOrDefault(i => i.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase));
                if (storeItem != null)
                {
                    storeItem.Quantity -= quantity;
                }
            }
        }
    }
}
