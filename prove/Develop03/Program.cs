using System; // Import the System namespace, which provides core functionality.
using System.Collections.Generic; // Import the namespace for working with lists.
using System.Linq; // Import the namespace for LINQ operations.
using System.Threading; // Import the namespace for working with threads.

class ScriptureWord
{
    public string Text { get; private set; } // Public property for the word text with a private setter.
    public bool Hidden { get; set; } // Public property for whether the word is hidden.

    public ScriptureWord(string text)
    {
        Text = text; // Initialize the Text property with the provided text.
        Hidden = false; // Set the Hidden property to false (word is not hidden) by default.
    }
}

class ScriptureReference
{
    public string FullReference { get; private set; } // Public property for the full scripture reference.

    public ScriptureReference(string reference)
    {
        FullReference = reference; // Initialize the FullReference property with the provided reference.
    }
}

class Scripture
{
    private List<ScriptureWord> words; // Private field to store the words of the scripture.
    private ScriptureReference reference; // Private field to store the scripture reference.

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference; // Initialize the reference field with the provided reference.
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
        // Split the text into words, create ScriptureWord objects for each word, and store them in the words list.
    }

    public void Display()
    {
        Console.WriteLine(reference.FullReference); // Display the full scripture reference.
        Console.WriteLine(GetVisibleText()); // Display the visible text of the scripture.
    }

    public string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.Hidden ? "*****" : word.Text));
        // Generate and return the visible text by joining words with spaces, replacing hidden words with "*****".
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.Hidden);
        // Check if all words in the scripture are hidden and return true if they are, false otherwise.
    }

    public void HideRandomWord()
    {
        List<ScriptureWord> visibleWords = words.Where(word => !word.Hidden).ToList();
        // Create a list of visible words by filtering out hidden words.
        if (visibleWords.Count > 0)
        {
            Random random = new Random();
            int indexToHide = random.Next(0, visibleWords.Count);
            visibleWords[indexToHide].Hidden = true; // Hide a random visible word.
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Clear(); // Clear the console screen.

        var reference = new ScriptureReference("John 3:16"); // Create a ScriptureReference for John 3:16.
        var text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        // Define the text of the scripture.
        var scripture = new Scripture(reference, text); // Create a Scripture object with the reference and text.

        // Main loop to hide words and display scripture
        while (!scripture.AllWordsHidden()) // Continue as long as not all words are hidden.
        {
            scripture.Display(); // Display the scripture.
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine(); // Prompt for user input.
            if (input.ToLower() == "quit") // If the user types 'quit,' exit the loop.
                break;
            scripture.HideRandomWord(); // Hide a random word in the scripture.
            Console.Clear(); // Clear the console screen for the next iteration.
        }

        // Final display
        scripture.Display(); // Display the scripture with hidden words.
        Console.WriteLine("\nAll words are hidden. Program ends."); // Inform the user that the program ends.
    }
}
