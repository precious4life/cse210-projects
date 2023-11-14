using System;
using System.Collections.Generic;
using System.Linq;


// Main program
class Program
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>();  // List to store created goals

        // Load goals from file (if any)

        while (true)
        {
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Display score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());  // Get user input

            switch (choice)
            {
                case 1:
                    // Create new goal
                    Console.WriteLine("Enter goal type (1. Simple, 2. Eternal, 3. Checklist):");
                    int goalType = Convert.ToInt32(Console.ReadLine());  // Get goal type from user

                    Console.WriteLine("Enter goal name:");
                    string goalName = Console.ReadLine();  // Get goal name from user

                    Console.WriteLine("Enter goal value:");
                    int goalValue = Convert.ToInt32(Console.ReadLine());  // Get goal value from user

                    Goal newGoal;  // Variable to store the newly created goal

                    switch (goalType)
                    {
                        case 1:
                            newGoal = new SimpleGoal(goalName, goalValue);  // Create a new simple goal
                            break;

                        case 2:
                            newGoal = new EternalGoal(goalName, goalValue);  // Create a new eternal goal
                            break;

                        case 3:
                            Console.WriteLine("Enter required times for checklist goal:");
                            int requiredTimes = Convert.ToInt32(Console.ReadLine());  // Get required times for checklist goal
                            newGoal = new ChecklistGoal(goalName, goalValue, requiredTimes);  // Create a new checklist goal
                            break;

                        default:
                            Console.WriteLine("Invalid goal type.");
                            continue;
                    }

                    goals.Add(newGoal);  // Add the newly created goal to the list
                    break;

                case 2:
                    // Record event
                    Console.WriteLine("Enter the name of the goal you completed:");
                    string completedGoal = Console.ReadLine();  // Get completed goal name from user

                    Goal goalToRecord = goals.Find(g => g.Name == completedGoal);  // Find the goal to record

                    if (goalToRecord != null)
                    {
                        goalToRecord.RecordEvent();  // Record the event for the found goal
                    }
                    else
                    {
                        Console.WriteLine("Goal not found.");
                    }
                    break;

                case 3:
                    // Display goals
                    foreach (Goal goal in goals)
                    {
                        goal.DisplayProgress();  // Display progress for each goal
                    }
                    break;

                case 4:
                    // Display score
                    int totalScore = goals.Sum(g => g.Value);  // Calculate total score
                    Console.WriteLine($"Total Score: {totalScore}");  // Display total score
                    break;

                case 5:
                    // Save goals to file
                    SaveGoalsToFile(goals);  // Call method to save goals to a file
                    break;

                case 6:
                    // Exit
                    SaveGoalsToFile(goals);  // Save before exiting
                    Environment.Exit(0);      // Exit the program
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
