


namespace vending_machine
{
    
    public interface IVending
    {
        void InsertMoney(int amount);
        Product Purchase(int productId);
        List<string> ShowAll();
        string Details(int productId);
        Dictionary<int, int> EndTransaction();
    }

   
}
