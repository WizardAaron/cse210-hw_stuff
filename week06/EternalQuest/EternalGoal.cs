class EternalGoal : Goal
{
    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded progress for '{Name}'. You earned {Points} points.");
    }

    public override string GetStatus()
    {
        return "[∞] " + Name;
    }
}