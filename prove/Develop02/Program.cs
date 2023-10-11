using System;
using System.Collections.Generic;
using System.IO;
namespace journal;




class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        journal.WriteNewEntry();
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        Console.Write("Enter a filename to save your journal as a CSV file: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveJournalToCSV(saveFileName);
                        break;
                    case 4:
                        Console.Write("Enter the filename to load your journal from a CSV file: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadJournalFromCSV(loadFileName);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
