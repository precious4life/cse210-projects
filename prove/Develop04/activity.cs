class Activity
{
    protected string name;
    protected string description;
    protected int duration;
    protected int countdownDuration = 3;

    public virtual void Start()
    {
        Console.WriteLine($"Starting {name} Activity...");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(countdownDuration * 1000);
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(countdownDuration * 1000);
    }

    protected void DisplayCountdown()
    {
        for (int i = countdownDuration; i > 0; i--)
        {
            Console.WriteLine($"Time left: {i} seconds");
            Thread.Sleep(1000);
        }
    }
}