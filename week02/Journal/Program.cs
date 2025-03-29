// Pretty proud of how this coding project went haha! The program asks you a 
// few questions, and gives you an opportunity to write down any other notes
// you may want in your journal entry. PREREQUISITE: You must have a folder
// named "Journal Entries" on your Desktop.
// Note: I found out that saving the file doesn't work from the browser, you
// must use VS Code or something of the sort.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
{
    Entry currentEntry = new Entry();
    // Initialize answeredQuestions dictionary
    Dictionary<int, string> answeredQuestions = new Dictionary<int, string>();
    bool running = true;

    // Keeps the program running in a loop until the user chooses to quit
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
                WriteEntry(currentEntry, answeredQuestions);
                break;

            case "2": // Display
                Console.WriteLine(" ");
                DisplayAnsweredQuestions(currentEntry, answeredQuestions);
                break;

            case "3": // Load
                Console.WriteLine(" ");
                LoadEntry(currentEntry);
                break;

            case "4": // Save
                Console.WriteLine(" ");
                SaveEntry(answeredQuestions);
                break;

            case "5": // Quit
                // Gracefully exits the program
                running = false;
                Console.WriteLine(" ");
                Console.WriteLine("Goodbye!");
                break;

            default:
                // Handles invalid menu inputs
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                break;
        }
    }
}

    // Allows the user to write a response to one randomly selected question
    static void WriteEntry(Entry entry, Dictionary<int, string> answeredQuestions)
    {
        // List of questions
        string[] questions = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was your concentration score today (as a number)?",
            "What was the best part of your day?",
            "How did you see the Lord's hand in your life today?",
            "What was the strongest emotion you felt today?",
            "What is one thing you would have done over?",
            "What is at least one goal you have for tomorrow?",
            "Extra thoughts or notes?"
        };

        // RNG to select a random question
        Random random = new Random();
        int randomIndex = random.Next(questions.Length);

        // Ensures that only unanswered questions are selected
        while (answeredQuestions.ContainsKey(randomIndex))
        {
            randomIndex = random.Next(questions.Length); // Picks another random question
        }

        // Asks the random question
        Console.Write(questions[randomIndex] + ": ");
        string response = Console.ReadLine();

        // Stores the response in the corresponding property and tracks it
        answeredQuestions[randomIndex] = response;
        switch (randomIndex)
        {
            case 0:
                entry._interestingPerson = response;
                break;
            case 1:
                if (float.TryParse(response, out float concentrationScore))
                {
                    entry._concentrationScore = concentrationScore;
                }
                else
                {
                    Console.WriteLine("Invalid input. Defaulting concentration score to 0.");
                    entry._concentrationScore = -1;
                }
                break;
            case 2:
                entry._bestPart = response;
                break;
            case 3:
                entry._theLordsHand = response;
                break;
            case 4:
                entry._strongestEmotion = response;
                break;
            case 5:
                entry._doOver = response;
                break;
            case 6:
                entry._tomorrowGoal = response;
                break;
            case 7:
                entry._anythingElse = response;
                break;
        }
    }

    // Displays only the answered questions and their responses
    static void DisplayAnsweredQuestions(Entry entry, Dictionary<int, string> answeredQuestions)
    {
        // List of questions
        string[] questions = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was your concentration score today (as a number)?",
            "What was the best part of your day?",
            "How did you see the Lord's hand in your life today?",
            "What was the strongest emotion you felt today?",
            "What is one thing you would have done over?",
            "What is at least one goal you have for tomorrow?",
            "Extra thoughts or notes?"
        };

        // If no questions have been answered, notify the user
        if (answeredQuestions.Count == 0)
        {
            Console.WriteLine("No questions have been answered yet.");
            return;
        }

        // Display the answered questions with their responses
        Console.WriteLine("Answered Questions:");
        foreach (var question in answeredQuestions)
        {
            Console.WriteLine($"{questions[question.Key]}: {question.Value}");
        }
    }

        // Saves only the randomly chosen questions and user responses to a file, including the prompts
        // Saves only the randomly chosen questions and user responses, showing the full prompt
    static void SaveEntry(Dictionary<int, string> answeredQuestions)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "Journal Entries");
        Directory.CreateDirectory(folderPath); // Ensure the folder exists

        string fileName = Path.Combine(folderPath, $"JournalEntry_{DateTime.Now:yyyyMMdd_HHmmss}_{DateTime.Now:MMMM_dd_yyyy}.txt");

        // List of questions to match indices
        string[] questions = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was your concentration score today (as a number)?",
            "What was the best part of your day?",
            "How did you see the Lord's hand in your life today?",
            "What was the strongest emotion you felt today?",
            "What is one thing you would have done over?",
            "What is at least one goal you have for tomorrow?",
            "Extra thoughts or notes?"
        };

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Journal Entry:");

            // Iterate through the answeredQuestions dictionary
            foreach (var question in answeredQuestions)
            {
                // Use the key (index) to retrieve the question text
                writer.WriteLine($"{questions[question.Key]}: {question.Value}");
            }

            writer.WriteLine($"Date: {DateTime.Now:MMMM dd, yyyy}"); // Append the current date at the end
        }

        Console.WriteLine($"Entry saved to: {fileName}");
    }

    // Loads an existing journal entry file from the "Journal Entries" folder
    static void LoadEntry(Entry entry)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "Journal Entries");

        // Checks if the folder exists before trying to load files
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"The folder '{folderPath}' does not exist. Please create it or save an entry first.");
            return;
        }

        // Gets the list of journal entry files
        Console.WriteLine("Available files:");
        string[] files = Directory.GetFiles(folderPath, "*.txt");

        // If the folder is empty, notify the user
        if (files.Length == 0)
        {
            Console.WriteLine("No journal entries found in the folder.");
            return;
        }

        // Displays the list of files for the user to select
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        Console.Write("Select a file number to load: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int fileIndex) && fileIndex > 0 && fileIndex <= files.Length)
        {
            // Reads and displays the content of the selected file
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
