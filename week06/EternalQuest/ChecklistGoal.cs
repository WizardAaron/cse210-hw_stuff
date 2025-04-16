class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; } // Ensure this is public and has both get and set
    public int BonusPoints { get; set; }

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            Console.WriteLine($"Recorded progress for '{Name}'. You earned {Points} points.");

            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Congratulations! You've completed '{Name}' and earned a bonus of {BonusPoints} points!");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed.");
        }
    }

    public override string GetStatus()
    {
        return IsCompleted 
            ? $"[X] {Name} (Completed {CurrentCount}/{TargetCount} times)" 
            : $"[ ] {Name} (Completed {CurrentCount}/{TargetCount} times)";
    }
}