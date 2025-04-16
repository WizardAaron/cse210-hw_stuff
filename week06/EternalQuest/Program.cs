using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Please enter your name:");
        string userName = Console.ReadLine();
        Console.WriteLine($"\nHello, {userName}! Let's begin your quest.");

        EternalQuest quest = new EternalQuest();

        while (true)
        {
            Console.WriteLine("\nWelcome to Eternal Quest! Please choose an action:\n[1] Create Goal\n[2] Record Event\n[3] Show Goals\n[4] Show Score\n[5] Save Goals (Do this last to save updates to your Goals)\n[6] Load Goals (Do this first to avoid overriding previous data)\n[7] Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    quest.CreateGoal();
                    break;
                case 2:
                    quest.RecordEvent();
                    break;
                case 3:
                    quest.ShowGoals();
                    break;
                case 4:
                    quest.ShowScore();
                    break;
                case 5:
                    quest.SaveGoals();
                    break;
                case 6:
                    quest.LoadGoals();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
                }
            }
        }
    }
