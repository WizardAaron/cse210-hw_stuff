using System;
using System.Threading;

public class Listing : Activity
{
    // List of prompts for the listing activity
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public Listing() : base(
        "Welcome to the listing activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Method to start the listing activity
    public void StartListingActivity()
    {
        // Prompt the user for the duration (handled by the base class)
        string duration = GetActivityDuration();

        if (int.TryParse(duration, out int totalSeconds))
        {
            PrintWelcomeAndDuration(); // Print the welcome message and duration

            // Display "Prepare to begin" message with a countdown
            StartCountdown();

            // Perform the listing activity
            PerformListing(totalSeconds);

            // Conclude the activity with the standard finishing message
            PrintCompletionMessage(totalSeconds);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Please provide a numeric value.");
        }
    }

    // Method for the listing logic
    private void PerformListing(int totalSeconds)
    {
        Random random = new Random();
        int elapsedSeconds = 0;
        int itemCount = 0;

        // Display a random prompt
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"> {Prompts[random.Next(Prompts.Length)]}");
        Console.WriteLine("You will have a moment to think, then begin listing items.");

        // Countdown before listing begins
        Countdown(5); // Pause for 5 seconds to prepare (customizable)

        Console.WriteLine("\nStart listing items! Type your responses and press Enter for each.");

        // Collect user input until time runs out
        while (elapsedSeconds < totalSeconds)
        {
            Console.Write("> ");
            Console.ReadLine(); // Simulate user entering an item
            itemCount++;
            elapsedSeconds += 5; // Add time per item (customizable pause duration)
        }

        Console.WriteLine($"\nYou listed {itemCount} items during the activity!");
    }

    // Method to display a countdown animation
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i} seconds...");
            Thread.Sleep(1000); // Wait for 1 second
        }
    }

    // Method to print the completion message
    private void PrintCompletionMessage(int duration)
    {
        Console.WriteLine("\nActivity complete! Great job!");
        Console.WriteLine($"You completed the listing activity for {duration} seconds.");
    }
}