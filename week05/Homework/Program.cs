using System;

class Program
{
    static void Main(string[] args)
    {
        // Test WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        // Call GetSummary method
        string summary = writingAssignment.GetSummary();
        Console.WriteLine(summary);

        // Call GetWritingInformation method
        string writingInfo = writingAssignment.GetWritingInformation();
        Console.WriteLine(writingInfo);
    }
}