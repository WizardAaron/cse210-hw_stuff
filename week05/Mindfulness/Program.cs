using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.WriteLine("\nWelcome to the Mindfulness Program!");
            Console.WriteLine("Choose one of the following activity types:");
            Console.WriteLine("> Breathing\n> Reflection\n> Listing\n> Quit");
            Console.Write("Choose activity (or type 'quit' to exit): ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() == "breathing")
            {
                Breathing breathingActivity = new Breathing();
                breathingActivity.StartBreathingActivity();
            }
            else
            if (userInput.ToLower() == "reflection")
            {
                Reflection reflectionActivity = new Reflection();
                reflectionActivity.StartReflectionActivity();
            }
            else
            if (userInput.ToLower() == "listing")
            {
                Listing listingActivity = new Listing();
                listingActivity.StartListingActivity();
            }
            else
            if (userInput.ToLower() != "quit" && userInput.ToLower() != "breathing" && userInput.ToLower() != "reflection" && userInput.ToLower() != "listing")
            {
                Console.WriteLine("Unknwon prompt. Please check the options and try again.");
            }
        }

        Console.WriteLine("Exiting program... Goodbye!");
    }
}