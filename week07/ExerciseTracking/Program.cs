using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        Activity[] activities = new Activity[]
        {
            new Running("03 Nov 2024", 30, 3.0),
            new Cycling("04 Nov 2024", 40, 15.0),
            new Swimming("05 Nov 2024", 20, 10)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}