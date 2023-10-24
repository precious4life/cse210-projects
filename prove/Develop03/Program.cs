using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a ScriptureReference for a scripture passage (e.g., "John 3:16").
        ScriptureReference reference = new ScriptureReference("John 3:16");

        // Create a Scripture with the scripture text and reference.
        Scripture scripture = new Scripture(
            "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.",
            reference
        );

        while (!scripture.IsAllWordsHidden())
        {
            scripture.DisplayScripture();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "quit")
            {
                break;
            }
            
            scripture.HideRandomWords();
        }

        Console.WriteLine("All words are hidden. Scripture memorized!");
    }
}
