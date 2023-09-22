using System;

namespace Viktors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my little shop!");
            Console.Write("What's your name? ");
            var name = Console.ReadLine();

            Console.WriteLine($"\nHello, {name}!");

            var shop = new Store();
            var cart = new ShoppingCart();
            var customer = new Customer(name, 500.0m);  

            bool shopping = true;
            while (shopping)
            {
                Console.WriteLine("\nHere's what we have in store:");
                shop.DisplayItems();

                Console.WriteLine($"\n{name}, you currently have {customer.GetBalance()} kr in your wallet.");
                Console.Write("What would you like to add to your shopping cart? ");
                var itemChoice = Console.ReadLine();

                if (shop.HasItem(itemChoice))
                {
                    Console.Write("How many do you want? ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        var item = shop.GetItem(itemChoice);
                        if (item != null && cart.AddItem(item, quantity, customer.GetBalance()))
                        {
                            customer.DeductFromBalance(item.Price * quantity);
                            shop.DeductQuantity(item, quantity);
                            Console.WriteLine($"\n{name}, you added {quantity} {itemChoice} to your shopping cart.");
                            Console.WriteLine($"Your current balance is {customer.GetBalance()} kr.");
                        }
                        else
                        {
                            Console.WriteLine("Couldn't add the item. Maybe you don't have enough funds or we're out of stock.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity entered.");
                    }
                }
                else
                {
                    Console.WriteLine("I don't have that...");
                }

                Console.Write("\nDo you want to continue shopping? (yes/no): ");
                var response = Console.ReadLine().ToLower();
                shopping = response == "yes";

                if (!shopping)
                {
                    cart.DisplayCartItems();
                    Console.WriteLine($"\nBye, {name}! Your total was {cart.GetTotalCost()} kr. Thanks for shopping with us!");
                }
            }
        }
    }
}
