using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private string text;
    private Reference reference;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    public Reference GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        return text;
    }

    public bool IsHidden()
    {
        return text.Contains("**********");
    }

    public void HideRandomWord()
    {
        if (!IsHidden())
        {
            var words = text.Split(' ');
            Random random = new Random();
            int wordIndex = random.Next(0, words.Length);
            words[wordIndex] = "**********";
            text = string.Join(' ', words);
        }
    }
}

public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');
        string[] referenceParts = parts[1].Split(':');
        book = parts[0];
        chapter = int.Parse(referenceParts[0]);
        if (referenceParts[1].Contains("-"))
        {
            string[] verseParts = referenceParts[1].Split('-');
            startVerse = int.Parse(verseParts[0]);
            endVerse = int.Parse(verseParts[1]);
        }
        else
        {
            startVerse = int.Parse(referenceParts[1]);
            endVerse = startVerse;
        }
    }

    public override string ToString()
    {
        if (startVerse == endVerse)
            return $"{book} {chapter}:{startVerse}";
        else
            return $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a scripture reference (e.g., John 3:16):");
        string input = Console.ReadLine();

        Reference reference = new Reference(input);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his only ********** Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.IsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetReference());
            Console.WriteLine(scripture.GetText());

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Program ended.");
    }
}


