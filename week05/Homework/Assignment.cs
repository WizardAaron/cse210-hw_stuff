using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get the summary
    public string GetSummary()
    {
        return $"{_studentName}, {_topic}";
    }

    // Public getter for the student's name
    public string GetStudentName()
    {
        return _studentName;
    }
}
