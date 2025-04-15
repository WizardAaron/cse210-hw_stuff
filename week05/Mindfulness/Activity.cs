using System;
using System.Threading;

public class Activity
{
    private string _activityName;
    private string _description;
    private string _seconds;

    // Constructor
    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    // Method to prompt user for activity duration
    public void StartActivity()
    {
        _seconds = GetActivityDuration(); // Prompt for duration
        PrintWelcomeAndDuration();       // Print welcome and duration
        StartCountdown();                // Start countdown after printing duration
        StartActivityTimer();
    }

    // Method to prompt user for activity duration
    public string GetActivityDuration()
    {
        Console.WriteLine("How many seconds would you like the activity to last?");
        string duration = Console.ReadLine();
        return duration;
    }

    // Method to print welcome and duration
    public void PrintWelcomeAndDuration()
    {
        Console.WriteLine(_activityName);
        Console.WriteLine(_description);
        Console.WriteLine($"Duration for this activity: {_seconds} seconds.");
    }

    // Method to start a countdown timer
    public void StartCountdown()
    {
        Console.WriteLine("Preparing to start your activity...");
        for (int i = 15; i > 0; i--)
        {
            Console.Write($"\rActivity starts in {i} seconds");
            Thread.Sleep(1000); // Pause for 1 second
        }

        Console.WriteLine("\nStarting your activity now...");
    }

    private void StartActivityTimer()
    {
        if (int.TryParse(_seconds, out int duration))
        {
            Console.WriteLine($"Activity running for {duration} seconds...");
            for (int i = duration; i > 0; i--)
            {
                Console.Write($"\rTime remaining: {i} seconds");
                Thread.Sleep(1000); // Pause for 1 second
            }
        }
        else
        {
           Console.WriteLine("Invalid duration input. Please ensure you provide a numeric value.");
       }
    }

    // Method to get the summary
    public string GetSummary()
    {
        return $"{_activityName}\n{_description}\nDuration: {_seconds} seconds";
    }

    // Public getters
    public string GetActivityName()
    {
        return _activityName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public string GetSeconds()
    {
        return _seconds;
    }
}