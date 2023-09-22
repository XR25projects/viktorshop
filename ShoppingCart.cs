using System;
using System.Collections.Generic;
using System.Linq;

namespace Viktors
{
    public class ShoppingCart
    {
        private List<CartItem> items;

        public ShoppingCart()
        {
            items = new List<CartItem>();
        }

        public bool AddItem(Item item, int quantity, decimal currentBalance)
        {
            if (item != null && item.Price * quantity <= currentBalance)
            {
                var existingItem = items.FirstOrDefault(i => i.Item.Name == item.Name);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    items.Add(new CartItem(item, quantity));
                }
                return true;
            }
            return false;
        }

        public void DisplayCartItems()
        {
            Console.WriteLine("\nItems in your cart:");
            foreach (var cartItem in items)
            {
                Console.WriteLine($"{cartItem.Item.Name} - {cartItem.Quantity} - Total: {cartItem.Quantity * cartItem.Item.Price} kr");
            }
        }

        public decimal GetTotalCost()
        {
            return items.Sum(cartItem => cartItem.Item.Price * cartItem.Quantity);
        }

        private class CartItem
        {
            public Item Item { get; set; }
            public int Quantity { get; set; }

            public CartItem(Item item, int quantity)
            {
                Item = item;
                Quantity = quantity;
            }
        }
    }
}
