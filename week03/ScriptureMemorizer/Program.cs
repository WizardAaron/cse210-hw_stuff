using System;

class Program
{
    static void Main()
    {
        // Reference and Scripture
        Reference reference = new Reference("1 Nephi", 3, 6-7);
        Scripture scripture = new Scripture(reference, "Therefore go, my son, and thou shalt be favored of the Lord, because thou hast not murmured; And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        // I have these copied here for convenience! (totally not just being lazy)
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            // Prompts the user as whether to continue or not
            Console.WriteLine("Press Enter to hide 3 random words, or type 'quit' to exit: ");
            
            // Waits for user input
            string input = Console.ReadLine();

            // Checks if the user wants to quit
            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            // Clears the console
            Console.Clear();

            // Hides 3 random words
            scripture.HideRandomWords(3);

            // Prints scripture with hidden words up to this point
            Console.WriteLine(scripture.GetDisplayText());

            // When all the words are hidden, ends the program
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words have been hidden!");
                break;
            }
        }
    }
}
