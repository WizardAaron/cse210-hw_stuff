abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}