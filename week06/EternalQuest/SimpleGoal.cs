class SimpleGoal : Goal
{
    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed.");
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}