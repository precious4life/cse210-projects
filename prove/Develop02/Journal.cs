using System;
using System.Collections.Generic;
using System.IO;


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

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine("Prompt: " + prompt);

        Console.WriteLine("Enter your journal entry:");
        string entryText = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        entries.Add(new JournalEntry { Prompt = prompt, EntryText = entryText, Date = date });
        Console.WriteLine("Entry saved successfully.");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Entry: {entry.EntryText}\n");
        }
    }

    public void SaveJournalToCSV(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Date,Prompt,EntryText");
            foreach (var entry in entries)
            {
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