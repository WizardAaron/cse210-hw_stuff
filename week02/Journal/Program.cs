//Pretty proud of how this coding project went haha! The program asks you a 
//few questions, and gives you an oppurtunity to write down any other notes
//you may want in your journal entry. PREREQUISITE: You must have a folder
//named "Journal Entries" on your Desktop.


using System;
using System.IO;

class Program
{
    // Note for anyone testing this code:
    // Your Journal Entry will save to a folder named "Entries" on your Desktop
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

        Console.Write("What is at least one goal you have for tomorrow?: ");
        entry1._tomorrowGoal = Console.ReadLine();

        Console.Write("Extra: ");
        entry1._anythingElse = Console.ReadLine();

        entry1.Display();

        // I decided to add a place to store my Journal entries in the folder" Journal Entries" on my desktop
        // (I had to look a lot of stuff up for this one)
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        string folderPath = Path.Combine(desktopPath, "Journal Entries");
        Directory.CreateDirectory(folderPath);

        // Makes a new file in the "Journal Entries" folder on the Desktop
        string fileName = Path.Combine(folderPath, $"JournalEntry_{DateTime.Now:yyyyMMdd_HHmmss}_{DateTime.Now:MMMM_dd_yyyy}.txt");
        File.WriteAllText(fileName, $"Journal Entry:\n"
                            + $"Interesting Person: {entry1._interestingPerson}\n"
                            + $"Concentration Score: {entry1._concentrationScore}\n"
                            + $"Best Part of the Day: {entry1._bestPart}\n"
                            + $"The Lord's Hand: {entry1._theLordsHand}\n"
                            + $"Strongest Emotion: {entry1._strongestEmotion}\n"
                            + $"Do Over: {entry1._doOver}\n"
                            + $"Goal(s) for tomorrow: {entry1._tomorrowGoal}\n"
                            + $"Anything Else: {entry1._anythingElse}\n"
                            + $"Date: {DateTime.Now:MMMM dd, yyyy}\n");
    }
}
