class ReflectionActivity : Activity
{
    public ReflectionActivity()
    {
        name = "Reflection";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Think of a time when you stood up for someone else.");
        DisplayCountdown();
        // Continue with more prompts and questions
        Console.WriteLine($"Great job! You completed the {name} Activity.");
    }
}