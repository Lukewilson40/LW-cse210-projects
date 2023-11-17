using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        QuestManager questManager = new QuestManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    questManager.CreateGoal();
                    break;
                case "2":
                    questManager.RecordEvent();
                    break;
                case "3":
                    questManager.DisplayGoals();
                    break;
                case "4":
                    questManager.DisplayScore();
                    break;
                case "5":
                    questManager.SaveGoals();
                    break;
                case "6":
                    questManager.LoadGoals();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class Goal
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public int Score { get; set; }

    public virtual void RecordEvent()
    {
        IsCompleted = true;
        Console.WriteLine($"Goal '{Name}' completed! You earned {Score} points.");
    }

    public virtual void Display()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name}");
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int score)
    {
        Name = name;
        Score = score;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        Console.WriteLine($"You've earned additional points for your eternal goal: {Score}");
    }
}

class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int requiredTimes;

    public ChecklistGoal(string name, int score, int requiredTimes)
    {
        Name = name;
        Score = score;
        this.requiredTimes = requiredTimes;
    }

    public override void RecordEvent()
    {
        timesCompleted++;

        if (timesCompleted < requiredTimes)
        {
            Console.WriteLine($"You've completed {timesCompleted}/{requiredTimes} times. Earned {Score} points.");
        }
        else
        {
            base.RecordEvent();
            Console.WriteLine($"Bonus! You've completed the goal {requiredTimes} times. Earned additional {Score} points.");
        }
    }

    public override void Display()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name} (Completed {timesCompleted}/{requiredTimes} times)");
    }
}

class QuestManager
{
    private List<Goal> goals = new List<Goal>();

    public void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal type (1: Simple, 2: Eternal, 3: Checklist): ");
        string type = Console.ReadLine();

        Console.Write("Enter score for the goal: ");
        if (!int.TryParse(Console.ReadLine(), out int score) || score < 0)
        {
            Console.WriteLine("Invalid score. Please enter a non-negative integer.");
            return;
        }

        Goal goal;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, score);
                break;
            case "2":
                goal = new EternalGoal(name, score);
                break;
            case "3":
                Console.Write("Enter required times for the checklist goal: ");
                if (!int.TryParse(Console.ReadLine(), out int requiredTimes) || requiredTimes < 0)
                {
                    Console.WriteLine("Invalid required times. Please enter a non-negative integer.");
                    return;
                }
                goal = new ChecklistGoal(name, score, requiredTimes);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine($"Goal '{name}' created successfully.");
    }

    public void RecordEvent()
    {
        Console.Write("Enter the name of the goal you want to record an event for: ");
        string goalName = Console.ReadLine();

        Goal goal = goals.Find(g => g.Name == goalName);

        if (goal != null)
        {
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            goal.Display();
        }
    }

    public void DisplayScore()
    {
        int totalScore = goals.Sum(g => g.Score);
        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void SaveGoals()
    {
        // Implement saving goals to a file or database
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        // Implement loading goals from a file or database
        Console.WriteLine("Goals loaded successfully.");
    }
}
