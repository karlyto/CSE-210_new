using System;

public class SavingsGoal
{
    public string Name { get; set; }
    public double TargetAmount { get; set; }
    public double Progress { get; set; }

    public SavingsGoal()
    {
        Progress = 0;
    }

    public SavingsGoal(string name, double targetAmount)
    {
        Name = name;
        TargetAmount = targetAmount;
        Progress = 0;
    }

    internal static void SetSavingsGoal(User loggedInUser, string goalName, double goalAmount)
    {
        if (loggedInUser == null)
        {
            throw new ArgumentNullException(nameof(loggedInUser), "Logged-in user cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(goalName))
        {
            throw new ArgumentException("Goal name cannot be empty or whitespace.");
        }

        if (goalAmount <= 0)
        {
            throw new ArgumentException("Goal amount must be greater than zero.");
        }

        SavingsGoal savingsGoal = new SavingsGoal(goalName, goalAmount);
        loggedInUser.SavingsGoals.Add(savingsGoal);
    }
}
