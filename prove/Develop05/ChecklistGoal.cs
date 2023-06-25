class ChecklistGoal : Goal
{
    private int requiredCount;
    private int completionCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonusPoints)
        : base(name, description, points)
    {
        this.requiredCount = requiredCount;
        this.bonusPoints = bonusPoints;
        completionCount = 0;
    }

    public override void RecordEvent()
    {
        completionCount++;
        Console.WriteLine($"Progress recorded for goal '{name}' ({completionCount}/{requiredCount}).");

        if (completionCount >= requiredCount)
        {
            completed = true;
            Console.WriteLine($"Goal '{name}' completed!");
        }
    }

    protected override int CalculatePoints()
    {
        return points + (bonusPoints * (completionCount - 1));
    }

    public override string ToString()
    {
        return $"[{(completed ? "X" : " ")}] {name} - {description} (Completed {completionCount}/{requiredCount} times)";
    }
}
