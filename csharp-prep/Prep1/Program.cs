using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("What is your firstname? ");
        string firstName = Console.ReadLine();

        Console.Write("What is last firstname? ");
        string lastName = Console.ReadLine();

        Console.Write($"Your name is {lastName}, {firstName} {lastName}");

    }
}