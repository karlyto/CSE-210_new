using System;
using System.Collections.Generic;

public class BudgetManager
{
    private Dictionary<User, List<Budget>> _budgets;

    public BudgetManager()
    {
        _budgets = new Dictionary<User, List<Budget>>();
    }

    public void SetBudget(User user, Budget budget)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (budget == null)
        {
            throw new ArgumentNullException(nameof(budget), "Budget object cannot be null.");
        }

        if (!_budgets.ContainsKey(user))
        {
            _budgets[user] = new List<Budget>();
        }

        string category = budget.Category;
        double amount = budget.Amount;

        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentException("Category cannot be empty or null.");
        }

        Budget existingBudget = _budgets[user].Find(b => b.Category == category);

        if (existingBudget != null)
        {
            existingBudget.Amount = amount;
        }
        else
        {
            _budgets[user].Add(budget);
        }
    }

    public double GetTotalBudget(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        double total = 0;

        if (_budgets.ContainsKey(user))
        {
            foreach (Budget budget in _budgets[user])
            {
                total += budget.Amount;
            }
        }

        return total;
    }
}
