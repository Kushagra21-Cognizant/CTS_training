using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> names = new List<string>();
    static List<int> numbers = new List<int>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Name");
            Console.WriteLine("2. Add Number");
            Console.WriteLine("3. Save to Text File");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddName();
                    break;
                case "2":
                    AddNumber();
                    break;
                case "3":
                    SaveToFile();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddName()
    {
        Console.Write("Enter a name: ");
        string name = Console.ReadLine();
        names.Add(name);
        Console.WriteLine("Name added.");
    }

    static void AddNumber()
    {
        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            numbers.Add(number);
            Console.WriteLine("Number added.");
        }
        else
        {
            Console.WriteLine("Invalid number. Please try again.");
        }
    }

    static void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                writer.WriteLine("Names:");
                foreach (string name in names)
                {
                    writer.WriteLine(name);
                }

                writer.WriteLine("Numbers:");
                foreach (int number in numbers)
                {
                    writer.WriteLine(number.ToString());
                }
            }
            Console.WriteLine("Data saved to output.txt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
 
}
