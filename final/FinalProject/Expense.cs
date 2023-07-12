public class Expense
{
    public string Category { get; set; }
    public double Amount { get; set; }

    public Expense() { }

    public Expense(string category, double amount)
    {
        Category = category;
        Amount = amount;
    }
}
