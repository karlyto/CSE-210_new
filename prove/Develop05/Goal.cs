using System;

abstract class Goal
{
    protected string name;
    protected string description;
    protected bool completed;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        completed = false;
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public virtual void RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            Console.WriteLine($"Goal '{name}' completed!");
        }
        else
        {
            Console.WriteLine($"Goal '{name}' is already completed.");
        }
    }

    protected abstract int CalculatePoints();

    public override string ToString()
    {
        return $"[{(completed ? "X" : " ")}] {name} - {description}";
    }
}
