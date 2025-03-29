using System;

public class Entry
{
    public string _interestingPerson;
    public float _concentrationScore;
    public string _bestPart;
    public string _theLordsHand;
    public string _strongestEmotion;
    public string _doOver;
    public string _anythingElse;

    public void Display()
    {
        Console.WriteLine($"Your Journal Entry:");
        Console.WriteLine($"One interesting person I interacted with: {_interestingPerson}");
        Console.WriteLine($"Concentration Score: {_concentrationScore}");
        Console.WriteLine($"Best part of the day: {_bestPart}");
        Console.WriteLine($"How I saw the Lord's hand in my life today: {_theLordsHand}");
        Console.WriteLine($"Strongest emotion I felt today: {_strongestEmotion}");
        Console.WriteLine($"One thing I would have done over: {_doOver}");
    }
}
