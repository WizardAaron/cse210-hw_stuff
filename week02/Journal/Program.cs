//Pretty proud of how this coding project went haha! The program asks you a 
//few questions, and gives you an oppurtunity to write down any other notes
//you may want in your journal entry. PREREQUISITE: You must have a folder
//named "Journal Entries" on your Desktop.
//Note: I found out that saving the file doesn't work from the browser, you
//must use VScode or something of the sort.


using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Entry currentEntry = new Entry();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Write
                    Console.WriteLine(" ");
                    WriteEntry(currentEntry);
                    break;

                case "2": // Display
                    Console.WriteLine(" ");
                    currentEntry.Display();
                    break;

                case "3": // Load
                Console.WriteLine(" ");
                    LoadEntry(currentEntry);
                    break;

                case "4": // Save
                    Console.WriteLine(" ");
                    SaveEntry(currentEntry);
                    break;

                case "5": // Quit
                    running = false;
                    Console.WriteLine(" ");
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void WriteEntry(Entry entry)
    {
        Console.Write("Who was the most interesting person I interacted with today?: ");
        entry._interestingPerson = Console.ReadLine();

        Console.Write("What was your concentration score today (as a number)?: ");
        string input = Console.ReadLine();
        if (float.TryParse(input, out float concentrationScore))
        {
            entry._concentrationScore = concentrationScore;
        }
        else
        {
            Console.WriteLine("Invalid input. Defaulting concentration score to 0.");
            entry._concentrationScore = -1; // Default value
        }

        Console.Write("What was the best part of your day?: ");
        entry._bestPart = Console.ReadLine();

        Console.Write("How did you see the Lord's hand in your life today?: ");
        entry._theLordsHand = Console.ReadLine();

        Console.Write("What was the strongest emotion you felt today?: ");
        entry._strongestEmotion = Console.ReadLine();

        Console.Write("What is one thing you would have done over?: ");
        entry._doOver = Console.ReadLine();

        Console.Write("What is at least one goal you have for tomorrow?: ");
        entry._tomorrowGoal = Console.ReadLine();

        Console.Write("Extra: ");
        entry._anythingElse = Console.ReadLine();
    }
    
    // Makes a new file in the "Journal Entries" folder on the Desktop
    static void SaveEntry(Entry entry)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "Journal Entries");
        Directory.CreateDirectory(folderPath);

        string fileName = Path.Combine(folderPath, $"JournalEntry_{DateTime.Now:yyyyMMdd_HHmmss}_{DateTime.Now:MMMM_dd_yyyy}.txt");
        File.WriteAllText(fileName, $"Journal Entry:\n"
                                    + $"Interesting Person: {entry._interestingPerson}\n"
                                    + $"Concentration Score: {entry._concentrationScore}\n"
                                    + $"Best Part of the Day: {entry._bestPart}\n"
                                    + $"The Lord's Hand: {entry._theLordsHand}\n"
                                    + $"Strongest Emotion: {entry._strongestEmotion}\n"
                                    + $"Do Over: {entry._doOver}\n"
                                    + $"Goal(s) for tomorrow: {entry._tomorrowGoal}\n"
                                    + $"Anything Else: {entry._anythingElse}\n"
                                    + $"Date: {DateTime.Now:MMMM dd, yyyy}\n");

        Console.WriteLine($"Entry saved to: {fileName}");
    }

    static void LoadEntry(Entry entry)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "Journal Entries");

        // Checks if the folder is there
        if (!Directory.Exists(folderPath))
        {
          Console.WriteLine($"The folder '{folderPath}' does not exist. Please create it or save an entry first.");
          return;
        }

        // Get the list of files
            Console.WriteLine("Available files:");
        string[] files = Directory.GetFiles(folderPath, "*.txt");

        if (files.Length == 0) // If there are no files in the folder
        {
            Console.WriteLine("No journal entries found in the folder.");
            return; // Exit the method
        }

        // Display files for selection
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        Console.Write("Select a file number to load: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int fileIndex) && fileIndex > 0 && fileIndex <= files.Length)
        {
            string content = File.ReadAllText(files[fileIndex - 1]);
            Console.WriteLine("\nLoaded Entry:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}