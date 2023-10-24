public class ScriptureReference
{
    private string referenceText;
    private int startVerse;
    private int endVerse;

    public ScriptureReference(string referenceText)
    {
        this.referenceText = referenceText;
        ParseReference(referenceText);
    }

    public ScriptureReference(string referenceText, int startVerse, int endVerse)
    {
        this.referenceText = referenceText;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetReferenceText()
    {
        if (startVerse == 0)
        {
            return referenceText;
        }
        else if (startVerse == endVerse)
        {
            return $"{referenceText}, Verse {startVerse}";
        }
        else
        {
            return $"{referenceText}, Verses {startVerse}-{endVerse}";
        }
    }

    private void ParseReference(string referenceText)
    {
        // This method parses the reference text to extract startVerse and endVerse.
        // You need to implement this based on your input format.
        // For simplicity, this example assumes a simple format like "John 3:16" or "Proverbs 3:5-6".
    }
}
