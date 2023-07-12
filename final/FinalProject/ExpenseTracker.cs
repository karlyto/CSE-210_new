using System;
using System.Collections.Generic;

public class ExpenseTracker
{
    private Dictionary<User, List<Expense>> _expenses;

    public ExpenseTracker()
    {
        _expenses = new Dictionary<User, List<Expense>>();
    }

    public void AddExpense(User user, Expense expense)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (expense == null)
        {
            throw new ArgumentNullException(nameof(expense), "Expense object cannot be null.");
        }

        if (!_expenses.ContainsKey(user))
        {
            _expenses[user] = new List<Expense>();
        }

        _expenses[user].Add(expense);
    }

    public List<Expense> GetExpenses(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (_expenses.ContainsKey(user))
        {
            return _expenses[user];
        }

        return new List<Expense>();
    }
}
