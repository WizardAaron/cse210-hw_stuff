using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Developer";
        job1._company = "Blizzard";
        job1._startYear = 2010;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Employee";
        job2._company = "Tesla";
        job2._startYear = 2022;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Jeffrey Doge";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}