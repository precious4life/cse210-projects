using System;
using System.Collections.Generic;
using System.Linq;

// Base class for goals
public class Goal
{
    public string Name { get; set; }           // Name of the goal
    public int Value { get; set; }             // Value (points) associated with the goal
    public bool IsCompleted { get; set; }      // Indicates if the goal is completed

    public virtual void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' completed! You earned {Value} points.");  // Display completion message
        IsCompleted = true;   // Mark the goal as completed
    }

    public virtual void DisplayProgress()
    {
        Console.WriteLine($"Goal: {Name} - Completed: {(IsCompleted ? "Yes" : "No")}");  // Display goal progress
    }

    public virtual string GetSaveString()
    {
        return $"{Name},{Value},{IsCompleted}";  // Create a string representation for saving to a file
    }
}