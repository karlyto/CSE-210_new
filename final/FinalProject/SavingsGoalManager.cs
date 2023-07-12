using System;
using System.Collections.Generic;

public class SavingsGoalManager
{
    private Dictionary<User, SavingsGoal> _savingsGoals;

    public SavingsGoalManager()
    {
        _savingsGoals = new Dictionary<User, SavingsGoal>();
    }

    public void SetSavingsGoal(User user, string name, double targetAmount)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Savings goal name cannot be empty or null.");
        }

        if (targetAmount <= 0)
        {
            throw new ArgumentException("Target amount must be greater than zero.");
        }

        SavingsGoal savingsGoal = new SavingsGoal(name, targetAmount);
        _savingsGoals[user] = savingsGoal;
    }

    public double GetSavingsProgress(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (_savingsGoals.ContainsKey(user))
        {
            SavingsGoal savingsGoal = _savingsGoals[user];
            return savingsGoal.Progress;
        }

        return 0;
    }

    public void UpdateSavingsProgress(User user, double amount)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        }

        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (_savingsGoals.ContainsKey(user))
        {
            SavingsGoal savingsGoal = _savingsGoals[user];
            savingsGoal.Progress += amount;
        }
    }
}
