using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numerator:");
        int numerator = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter denomenator:");
        int denomenator = Convert.ToInt32(Console.ReadLine());

        Fraction f1 = new Fraction(numerator, denomenator);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
    }
}