using System;
using System.Threading;

public class Reflection : Activity
{
    // List of reflection prompts
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // List of reflection questions
    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor
    public Reflection() : base(
        "Welcome to the reflection activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    // Method to start the reflection activity
    public void StartReflectionActivity()
    {
        // Prompt the user for the duration (handled by the base class)
        string duration = GetActivityDuration();

        if (int.TryParse(duration, out int totalSeconds))
        {
            PrintWelcomeAndDuration(); // Print the welcome message and duration

            // Display "Prepare to begin" message with a countdown
            StartCountdown();

            // Perform the reflection activity
            PerformReflection(totalSeconds);

            // Conclude the activity with the standard finishing message
            PrintCompletionMessage(totalSeconds);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Please provide a numeric value.");
        }
    }

    // Method for the reflection logic
    private void PerformReflection(int totalSeconds)
    {
        Random random = new Random();
        int elapsedSeconds = 0;

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"> {Prompts[random.Next(Prompts.Length)]}");
        Console.WriteLine("When you're ready, reflect on the following questions:");

        while (elapsedSeconds < totalSeconds)
        {
            string question = Questions[random.Next(Questions.Length)];
            Console.WriteLine($"\n> {question}");
            Spinner(6); // Display spinner for 6 seconds (customizable)
            elapsedSeconds += 6;
        }
    }

    // Method to display a spinner animation
    private void Spinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250); // Quarter-second spin
            Console.Write("\b\\");
            Thread.Sleep(250); // Quarter-second spin
            Console.Write("\b-");
            Thread.Sleep(250); // Quarter-second spin
            Console.Write("\b|");
            Thread.Sleep(250); // Quarter-second spin
            Console.Write("\b");
        }
    }

    // Method to print the completion message
    private void PrintCompletionMessage(int duration)
    {
        Console.WriteLine("\nActivity complete! Great job!");
        Console.WriteLine($"You completed the reflection activity for {duration} seconds.");
    }
}