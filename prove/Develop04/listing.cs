using System;
class ListingActivity : Activity
{
    public ListingActivity()
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Who are people that you appreciate?");
        DisplayCountdown();
        // Continue with listing items
        Console.WriteLine($"Great job! You listed items for the {name} Activity.");
    }}