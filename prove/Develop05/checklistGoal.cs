public class ChecklistGoal : Goal
{
    private int completedTimes;  // Track how many times the goal has been completed
    private int requiredTimes;   // Number of times needed to complete the checklist goal

    public ChecklistGoal(string name, int value, int requiredTimes)
    {
        Name = name;                  // Initialize the name
        Value = value;                // Initialize the value
        this.requiredTimes = requiredTimes;  // Initialize the required times
    }

    public override void RecordEvent()
    {
        base.RecordEvent();  // Call the base class method
        completedTimes++;    // Increment completed times

        if (completedTimes == requiredTimes)
        {
            Console.WriteLine($"Bonus! You achieved the goal '{Name}' {requiredTimes} times. Bonus: {Value} points.");
            Value += Value;    // Bonus points for completing the checklist
            completedTimes = 0; // Reset completed times for future rounds
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"Goal: {Name} - Completed: {completedTimes}/{requiredTimes}");  // Display progress for checklist goals
    }

    public override string GetSaveString()
    {
        return $"{base.GetSaveString()},{completedTimes},{requiredTimes}";  // Extend the base class string representation
    }
}