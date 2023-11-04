class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Begin breathing...");
        for (int i = 5; i < duration; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
        Console.WriteLine($"Great job! You completed the {name} Activity.");
    }}