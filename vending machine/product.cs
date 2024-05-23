
public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }

    protected Product(int id, string name, int cost)
    {
        Id = id;
        Name = name;
        Cost = cost;
    }

    public abstract string Examine();
    public abstract string Use();
}


public class Drink : Product
    {
        public int Volume { get; }

        public Drink(int id, string name, int cost, int volume)
            : base(id, name, cost)
        {
            Volume = volume;
        }

        public override string Examine()
        {
            return $"{Name} (Drink): {Cost}kr, Volume: {Volume}ml";
        }

        public override string Use()
        {
            return $"You drink the {Name}.";
        }
    }

    public class Snack : Product
    {
        public int Calories { get; }

        public Snack(int id, string name, int cost, int calories)
            : base(id, name, cost)
        {
            Calories = calories;
        }

        public override string Examine()
        {
            return $"{Name} (Snack): {Cost}kr, Calories: {Calories}";
        }

        public override string Use()
        {
            return $"You eat the {Name}.";
        }
    }

public class Toy : Product
{
    public string Material { get; }

    public Toy(int id, string name, int cost, string material)
        : base(id, name, cost)
    {
        Material = material;
    }

    public override string Examine()
    {
        return $"{Name} (Toy): {Cost}kr, Material: {Material}";
    }

    public override string Use()
    {
        return $"You play with the {Name}.";
    }

}