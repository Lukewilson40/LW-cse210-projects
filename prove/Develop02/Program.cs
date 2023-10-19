using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}\n");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        for (int i = 0; i < lines.Length; i += 4)
        {
            Entry entry = new Entry
            {
                Date = lines[i].Substring("Date: ".Length),
                Prompt = lines[i + 1].Substring("Prompt: ".Length),
                Response = lines[i + 2].Substring("Response: ".Length)
            };
            entries.Add(entry);
        }
    }
}

class Program
{
    private static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private static Random random = new Random();

    private static string ShowRandomPrompt()
    {
        return prompts[random.Next(prompts.Count)];
    }

    private static void WriteNewEntry(Journal journal)
    {
        string prompt = ShowRandomPrompt();
        Console.WriteLine($"{prompt}");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        journal.AddEntry(new Entry { Prompt = prompt, Response = response, Date = date });
    }

    private static void MainMenu(Journal journal)
    {
        while (true)
        {
            Console.WriteLine("------ Journal Program ------");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the filename to save: ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved to file.");
                    break;
                case "4":
                    Console.Write("Enter the filename to load: ");
                    filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded from file.");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        MainMenu(journal);
    }
}