using System;
using System.Collections.Generic;
using System.Linq;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;    // Initialize the name
        Value = value;  // Initialize the value
    }
}

// Subclass for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;    // Initialize the name
        Value = value;  // Initialize the value
    }
    public override void RecordEvent()
    {
        base.RecordEvent();  // Call the base class method
        // Eternal goals are never completed, so no additional logic needed here
        IsCompleted = false; // Reset completion status for eternal goals
    }
}