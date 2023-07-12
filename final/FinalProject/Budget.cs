public class Budget
{
    public string Category { get; set; }
    public double Amount { get; set; }

    public Budget() { }

    public Budget(string category, double amount)
    {
        Category = category;
        Amount = amount;
    }
}
