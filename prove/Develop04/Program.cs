using System;
using System.Threading;

class MindfulnessActivity
{
    protected string name;
    protected int duration;

    public MindfulnessActivity(string name)
    {
        this.name = name;
        duration = 0;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin in 3 seconds.");
        Thread.Sleep(3000);
    }

    public void EndActivity()
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        Thread.Sleep(3000);
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing") { }

    public void DoActivity()
    {
        Console.WriteLine("This activity will help you relax by guiding you through deep breathing.");
        for (int i = 0; i < duration; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection") { }

    public void DoActivity()
    {
        Console.WriteLine("This activity will help you reflect on times when you demonstrated strength.");
        Console.WriteLine("Think about a challenging situation you've faced recently and how you overcame it.");
        for (int i = 0; i < duration; i++)
        {
            Thread.Sleep(1000);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing") { }

    public void DoActivity()
    {
        Console.WriteLine("This activity will help you list positive things in your life.");
        Console.WriteLine("List three things you're grateful for right now.");
        for (int i = 0; i < duration; i++)
        {
            Thread.Sleep(1000);
        }
    }
}

class Program
{
    static void Main()
    {
        string choice;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Choose an activity (1-4): ");
            choice = Console.ReadLine();

            if (choice == "4")
                break;

            switch (choice)
            {
                case "1":
                    var breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity();
                    breathingActivity.DoActivity();
                    breathingActivity.EndActivity();
                    break;
                case "2":
                    var reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity();
                    reflectionActivity.DoActivity();
                    reflectionActivity.EndActivity();
                    break;
                case "3":
                    var listingActivity = new ListingActivity();
                    listingActivity.StartActivity();
                    listingActivity.DoActivity();
                    listingActivity.EndActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }
        }
    }
}
