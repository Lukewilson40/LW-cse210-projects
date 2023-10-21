using System;
using System.Collections.Generic;

class TaskTracker
{
    private List<string> tasks = new List<string>();

    public void AddTask(string description)
    {
        tasks.Add(description);
    }

    public void ListTasks()
    {
        foreach (string task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}

class Program
{
    static void Main()
    {
        TaskTracker tracker = new TaskTracker();

        Console.WriteLine();
        Console.WriteLine("How many tasks do you have? ");
        int numtasks = Convert.ToInt32(Console.ReadLine());

        int i = 0;
        while (i < numtasks)
        {
            Console.WriteLine();
            Console.WriteLine("Input Task: ");
            string taskinput = Console.ReadLine();
            tracker.AddTask(taskinput);
            i++;
        }

        Console.WriteLine();
        Console.WriteLine("Tasks:");
        tracker.ListTasks();
        Console.WriteLine();
    }
}

