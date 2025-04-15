using System;
using System.Threading;

public class Breathing : Activity
{
    public Breathing() : base(
        "Welcome to the breathing activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Method to start the breathing activity
    public void StartBreathingActivity()
    {
        // Prompt the user for the duration (handled by the base class)
        string duration = GetActivityDuration();
        
        if (int.TryParse(duration, out int totalSeconds))
        {
            PrintWelcomeAndDuration(); // Print the welcome message and duration

            // Display "Prepare to begin" message with a countdown
            StartCountdown();

            // Perform the breathing activity
            PerformBreathing(totalSeconds);

            // Conclude the activity with the standard finishing message
            PrintCompletionMessage(totalSeconds);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Please provide a numeric value.");
        }
    }

    // Method for the breathing logic
    private void PerformBreathing(int totalSeconds)
    {
        int elapsedSeconds = 0;

        while (elapsedSeconds < totalSeconds)
        {
            Console.Write("\n    Breathe in...");
            Countdown(4); // Pause for 4 seconds (customizable)

            elapsedSeconds += 4; // Add time elapsed

            if (elapsedSeconds >= totalSeconds)
                break; // Ensure we don't exceed the total time

            Console.Write("\n    Breathe out...");
            Countdown(4); // Pause for 4 seconds (customizable)

            elapsedSeconds += 4; // Add time elapsed
        }
    }

    // Method for countdown animation
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000); // Wait for 1 second
        }
    }

    // Method to print the completion message
    private void PrintCompletionMessage(int duration)
    {
        Console.WriteLine("\nActivity complete! Great job!");
        Console.WriteLine($"You completed the breathing activity for {duration} seconds.");
    }
}