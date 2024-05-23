
using vending_machine;

public class VendingMachineService : IVending
{
    private List<Product> products = new List<Product>();
    private int moneyPool = 0;

    public VendingMachineService()
    {
        // Initialize with some products
        products.Add(new Drink(1, "Cola", 20, 100));
        products.Add(new Snack(2, "Chips", 15, 50 ));
        products.Add(new Toy(3, "Action Figure", 100, "Plastic"));
    }

    public void InsertMoney(int amount)
    {
        if (!MoneyDenominations.Denominations.Contains(amount))
            throw new ArgumentException("Invalid denomination");

        moneyPool += amount;
    }

    public Product Purchase(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
            throw new ArgumentException("Product not found");
        if (moneyPool < product.Cost)
            throw new InvalidOperationException("Insufficient funds");

        moneyPool -= product.Cost;
        return product;
    }

    public List<string> ShowAll()
    {
        return products.Select(p => $"{p.Id}. {p.Name} - {p.Cost}kr").ToList();
    }

    public string Details(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
            throw new ArgumentException("Product not found");

        return product.Examine();
    }

    public Dictionary<int, int> EndTransaction()
    {
        var change = new Dictionary<int, int>();
        foreach (var denom in MoneyDenominations.Denominations.OrderByDescending(d => d))
        {
            int count = moneyPool / denom;
            if (count > 0)
            {
                change[denom] = count;
                moneyPool %= denom;
            }
        }
        return change;
    }
}
