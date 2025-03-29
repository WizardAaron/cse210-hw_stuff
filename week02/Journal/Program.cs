using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Entry entry1 = new Entry();

        Console.Write("Who was the most interesting person I interacted with today?: ");
        entry1._interestingPerson = Console.ReadLine();

        Console.Write("What was your concentration score today (as a number)?: ");
        string input = Console.ReadLine();
        if (float.TryParse(input, out float concentrationScore))
        {
            entry1._concentrationScore = concentrationScore;
        }
        else
        {
            Console.WriteLine("Invalid input. Defaulting concentration score to 0.");
            entry1._concentrationScore = -1; // Default value
        }

        Console.Write("What was the best part of your day?: ");
        entry1._bestPart = Console.ReadLine();

        Console.Write("How did you see the Lord's hand in your life today?: ");
        entry1._theLordsHand = Console.ReadLine();

        Console.Write("What was the strongest emotion you felt today?: ");
        entry1._strongestEmotion = Console.ReadLine();

        Console.Write("What is one thing you would have done over?: ");
        entry1._doOver = Console.ReadLine();

        entry1.Display();

        // I decided to add a place to store my Journal entries (I had to look a lot of stuff up for this one)
        string fileName = Path.Combine("Entries", $"JournalEntry_{DateTime.Now:yyyyMMdd_HHmmss}_{DateTime.Now:MMMM_dd_yyyy}.txt");
        Directory.CreateDirectory("Entries");

        File.WriteAllText(fileName, $"Journal Entry:\n"
                            + $"Interesting Person: {entry1._interestingPerson}\n"
                            + $"Concentration Score: {entry1._concentrationScore}\n"
                            + $"Best Part of the Day: {entry1._bestPart}\n"
                            + $"The Lord's Hand: {entry1._theLordsHand}\n"
                            + $"Strongest Emotion: {entry1._strongestEmotion}\n"
                            + $"Do Over: {entry1._doOver}\n"
                            + $"Date: {DateTime.Now:MMMM dd, yyyy}\n");
    }
}
