using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numberEntered = -1;
        int sum = 0;
        while (numberEntered != 0)
        {
            Console.WriteLine("Enter number");
            numberEntered = int.Parse(Console.ReadLine());
            numbers.Add(numberEntered);
        }

        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");
        float average = ((float)sum)/(numbers.Count - 1);
        Console.WriteLine($"The avereage is {average}");

        int largest = numbers[0];

        foreach (int number in numbers)
        {
            if(number>largest)
            {
                largest = number;
            }
        }

        Console.WriteLine($"The largest number is {largest}");

    }
}