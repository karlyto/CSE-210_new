class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    protected override int CalculatePoints()
    {
        return points;
    }
}
