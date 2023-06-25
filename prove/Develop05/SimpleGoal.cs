class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    protected override int CalculatePoints()
    {
        return points;
    }
}
