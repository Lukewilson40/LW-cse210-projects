using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class ScriptureWord
{
    public string Text { get; private set; }
    public bool Hidden { get; set; }

    public ScriptureWord(string text)
    {
        Text = text;
        Hidden = false;
    }
}

class ScriptureReference
{
    public string FullReference { get; private set; }

    public ScriptureReference(string reference)
    {
        FullReference = reference;
    }
}

class Scripture
{
    private List<ScriptureWord> words;
    private ScriptureReference reference;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.FullReference);
        Console.WriteLine(GetVisibleText());
    }

    public string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.Hidden ? "*****" : word.Text));
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.Hidden);
    }

    public void HideRandomWord()
    {
        List<ScriptureWord> visibleWords = words.Where(word => !word.Hidden).ToList();
        if (visibleWords.Count > 0)
        {
            Random random = new Random();
            int indexToHide = random.Next(0, visibleWords.Count);
            visibleWords[indexToHide].Hidden = true;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Clear();

        var reference = new ScriptureReference("John 3:16");
        var text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        var scripture = new Scripture(reference, text);

        // Main loop to hide words and display scripture
        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            scripture.HideRandomWord();
            Console.Clear();
        }

        // Final display
        scripture.Display();
        Console.WriteLine("\nAll words are hidden. Program ends.");
    }
}



