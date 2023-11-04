class MindfulnessProgram
{
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Start();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Start();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Start();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}