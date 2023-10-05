using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt;
    public string EntryText;
    public string Date;
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private Random random = new Random();

    public void WriteNewEntry()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        // Randomly select a prompt from the array
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine("Prompt: " + prompt);

        Console.WriteLine("Enter your journal entry:");
        string entryText = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Create a new JournalEntry and add it to the list
        entries.Add(new JournalEntry { Prompt = prompt, EntryText = entryText, Date = date });
        Console.WriteLine("Entry saved successfully.");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            // Display date, prompt, and entry text for each entry in the list
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Entry: {entry.EntryText}\n");
        }
    }

    public void SaveJournalToCSV(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            // Write the header line to the CSV file
            writer.WriteLine("Date,Prompt,EntryText");
            foreach (var entry in entries)
            {
                // Write each journal entry to the CSV file
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.EntryText}");
            }
        }

        Console.WriteLine("Journal saved to CSV file successfully.");
    }

    public void LoadJournalFromCSV(string fileName)
    {
        if (File.Exists(fileName))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length > 0)
            {
                for (int i = 1; i < lines.Length; i++) // Start from 1 to skip the header line
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length == 3)
                    {
                        // Create JournalEntry objects from CSV data and add them to the list
                        entries.Add(new JournalEntry
                        {
                            Date = parts[0],
                            Prompt = parts[1],
                            EntryText = parts[2]
                        });
                    }
                }

                Console.WriteLine("Journal loaded from CSV file successfully.");
            }
            else
            {
                Console.WriteLine("CSV file is empty.");
            }
        }
        else
        {
            Console.WriteLine("CSV file not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry"); // Option to add a new journal entry
            Console.WriteLine("2. Display the journal"); // Option to display journal entries
            Console.WriteLine("3. Save the journal to a CSV file"); // Option to save journal to a CSV file
            Console.WriteLine("4. Load the journal from a CSV file"); // Option to load journal from a CSV file
            Console.WriteLine("5. Exit"); // Option to exit the program

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        journal.WriteNewEntry(); // Call the method to write a new journal entry
                        break;
                    case 2:
                        journal.DisplayJournal(); // Call the method to display journal entries
                        break;
                    case 3:
                        Console.Write("Enter a filename to save your journal as a CSV file: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveJournalToCSV(saveFileName); // Call the method to save journal to a CSV file
                        break;
                    case 4:
                        Console.Write("Enter the filename to load your journal from a CSV file: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadJournalFromCSV(loadFileName); // Call the method to load journal from a CSV file
                        break;
                    case 5:
                        Environment.Exit(0); // Exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again."); // Invalid input handling
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number."); // Input validation message
            }
        }
    }
}
