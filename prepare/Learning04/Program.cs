using System;

class Program
{
    static void Main()
    {
        MathAssignment mathAssignment = new MathAssignment(
            "Roberto Rodriguez",
            "Fractions",
            3,
            "Section 7.3 Problems 8-19"
        );

        string summary = mathAssignment.GetSummary();
        string homeworkList = mathAssignment.GetHomeworkList();

        Console.WriteLine(summary);
        Console.WriteLine(homeworkList);
    }
}
