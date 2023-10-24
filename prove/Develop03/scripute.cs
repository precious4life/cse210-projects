using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Scripture
{
    private string text;
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(string text, ScriptureReference reference)
    {
        this.text = text;
        this.reference = reference;
        InitializeWords();
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(reference.GetReferenceText());
        foreach (Word word in words)
        {
            if (word.IsHidden())
            {
                Console.Write(new string('*', word.GetText().Length) + " ");
            }
            else
            {
                Console.Write(word.GetText() + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        List<Word> visibleWords = words.FindAll(word => !word.IsHidden());
        
        if (visibleWords.Count == 0)
        {
            Console.WriteLine("All words are hidden. Scripture memorized!");
            return;
        }

        int randomIndex = random.Next(0, visibleWords.Count);
        visibleWords[randomIndex].Hide();
    }

    public bool IsAllWordsHidden()
    {
        return words.TrueForAll(word => word.IsHidden());
    }

    private void InitializeWords()
    {
        string[] wordArray = text.Split(' '); // Split the text into words
        words = new List<Word>();

        foreach (string wordText in wordArray)
        {
            words.Add(new Word(wordText));
        }
    }
}
