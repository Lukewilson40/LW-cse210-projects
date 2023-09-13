using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        //string interpolation
        //int myInt = 5;

        //Console.WriteLine($"my int = {myInt}");

        //readline
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        //Console.WriteLine($"name = {name}");

        //conditionals
        if (name == "Luke")
        {
            Console.WriteLine("Hi Luke");
        }
        else
        {
            Console.WriteLine($"Hi {name}");
        }


    }
}