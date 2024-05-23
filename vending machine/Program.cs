

public static class MoneyDenominations
{
    public static readonly int[] Denominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
}

class Program
{
    static void Main(string[] args)
    {
        VendingMachineService vendingMachine = new VendingMachineService();

        try
        {
            vendingMachine.InsertMoney(100);
            Console.WriteLine("Inserted 100kr");

            Console.WriteLine("Available products:");
            foreach (var product in vendingMachine.ShowAll())
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Details of product 1:");
            Console.WriteLine(vendingMachine.Details(1));

            Product purchasedProduct = vendingMachine.Purchase(1);
            Console.WriteLine($"Purchased: {purchasedProduct.Name}");
            Console.WriteLine(purchasedProduct.Use());

            var change = vendingMachine.EndTransaction();
            Console.WriteLine("Change returned:");
            foreach (var coin in change)
            {
                Console.WriteLine($"{coin.Value} x {coin.Key}kr");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}