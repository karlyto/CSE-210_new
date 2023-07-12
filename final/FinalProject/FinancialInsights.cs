using System;
using System.Collections.Generic;
using System.Linq;

public class FinancialInsights
{
    public List<ExpenseCategory> ExpenseCategories { get; private set; }

    public FinancialInsights()
    {
        ExpenseCategories = new List<ExpenseCategory>();
    }

    public void AnalyzeExpenses(List<Expense> expenses)
    {
        if (expenses == null)
        {
            throw new ArgumentNullException(nameof(expenses), "Expense list cannot be null.");
        }

        ExpenseCategories.Clear();

        var groupedExpenses = expenses.GroupBy(e => e.Category);

        foreach (var group in groupedExpenses)
        {
            double totalAmount = group.Sum(e => e.Amount);
            ExpenseCategory categoryExpense = new ExpenseCategory(group.Key, totalAmount);
            ExpenseCategories.Add(categoryExpense);
        }
    }
}

public class ExpenseCategory
{
    public string Category { get; set; }
    public double Amount { get; set; }

    public ExpenseCategory(string category, double amount)
    {
        Category = category;
        Amount = amount;
    }
}
