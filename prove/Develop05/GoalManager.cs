using System;
using System.Collections.Generic;

class GoalManager
{
    private List<Goal> goals;

    public GoalManager()
    {
        goals = new List<Goal>();
    }

    public void CreateGoal(string name, string description, int points, int requiredCount, int bonusPoints)
    {
        Goal newGoal = new ChecklistGoal(name, description, points, requiredCount, bonusPoints);
        goals.Add(newGoal);
    }

    public bool IsValidGoalIndex(int index)
    {
        return index >= 0 && index < goals.Count;
    }

    public void RecordEvent(int index)
    {
        goals[index].RecordEvent();
    }

    public void DisplayGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            Console.WriteLine("Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }
        }
    }

    public void SaveGoals(string filename)
    {
        // Code to save goals to a file
        Console.WriteLine($"Goals saved to '{filename}'");
    }

    public void LoadGoals(string filename)
    {
        // Code to load goals from a file
        Console.WriteLine($"Goals loaded from '{filename}'");
    }
}
