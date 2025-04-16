class EternalQuest
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: [1] Simple, [2] Eternal, [3] Checklist");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter points value:");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal { Name = name, Points = points });
                break;
            case 2:
                goals.Add(new EternalGoal { Name = name, Points = points });
                break;
            case 3:
                Console.WriteLine("Enter target count:");
                int targetCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal { Name = name, Points = points, TargetCount = targetCount, BonusPoints = bonusPoints });
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Choose a goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            Goal goal = goals[choice];
            goal.RecordEvent();
            score += goal.Points;

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
            {
                score += checklistGoal.BonusPoints;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Current score: {score}");
    }

    public void SaveGoals()
    {
    string filePath = "/workspaces/cse210-hw_stuff/week06/EternalQuest/goals.txt"; // Fixed file path

    using (StreamWriter writer = new StreamWriter(filePath, false)) // Overwrite the file completely
    {
        writer.WriteLine(score); // Save the score

        foreach (Goal goal in goals)
        {
            string goalType = goal.GetType().Name;

            if (goal is ChecklistGoal checklistGoal)
            {
                writer.WriteLine($"{goalType}|{goal.GetStatus()}|{goal.Points}|{goal.Name}|{checklistGoal.CurrentCount}|{checklistGoal.TargetCount}|{checklistGoal.BonusPoints}");
            }
            else
            {
                writer.WriteLine($"{goalType}|{goal.GetStatus()}|{goal.Points}|{goal.Name}");
            }
        }
    }

    Console.WriteLine("Goals have been saved to /workspaces/cse210-hw_stuff/week06/EternalQuest/goals.txt.");
    }

    public void LoadGoals()
{
    string filePath = "/workspaces/cse210-hw_stuff/week06/EternalQuest/goals.txt"; // Fixed file path

    if (File.Exists(filePath))
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            try
            {
                score = int.Parse(reader.ReadLine());
                goals.Clear(); // Clear existing goals before loading new ones

                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split('|');

                    // Skip malformed lines
                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Error loading goal from line: {string.Join('|', parts)}");
                        continue;
                    }

                    string goalType = parts[0];
                    string name = parts[3];
                    int points = int.Parse(parts[2]);

                    if (goalType == nameof(SimpleGoal))
                    {
                        goals.Add(new SimpleGoal { Name = name, Points = points });
                    }
                    else if (goalType == nameof(EternalGoal))
                    {
                        goals.Add(new EternalGoal { Name = name, Points = points });
                    }
                    else if (goalType == nameof(ChecklistGoal))
                    {
                        if (parts.Length >= 7) // Ensure enough components exist for ChecklistGoal
                        {
                            int currentCount = int.Parse(parts[4]);
                            int targetCount = int.Parse(parts[5]);
                            int bonusPoints = int.Parse(parts[6]);
                            goals.Add(new ChecklistGoal
                            {
                                Name = name,
                                Points = points,
                                TargetCount = targetCount,
                                BonusPoints = bonusPoints
                            });

                            // Restore the progress
                            ((ChecklistGoal)goals[goals.Count - 1]).CurrentCount = currentCount;
                        }
                        else
                        {
                            Console.WriteLine($"Error loading ChecklistGoal from line: {string.Join('|', parts)}");
                        }
                    }
                }

                Console.WriteLine("Goals have been loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
            }
        }
    }
    else
    {
        Console.WriteLine("No saved goals found at /workspaces/cse210-hw_stuff/week06/EternalQuest/goals.txt.");
    }
}
}