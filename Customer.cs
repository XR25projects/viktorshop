namespace Viktors
{
    public class Customer
    {
        public string Name { get; private set; }
        private decimal balance;

        public Customer(string name, decimal initialFunds)
        {
            Name = name;
            balance = initialFunds;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public bool DeductFromBalance(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
    }
}
