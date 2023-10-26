using System;

public class Assignment
{
    public string Name { get; set; }
    public string Topic { get; set; }
    public int Difficulty { get; set; }

    public Assignment(string name, string topic, int difficulty)
    {
        Name = name;
        Topic = topic;
        Difficulty = difficulty;
    }

    public string GetSummary()
    {
        return $"{Name} - {Topic}";
    }
}

public class MathAssignment : Assignment
{
    private string homeworkList;

    public MathAssignment(string name, string topic, int difficulty, string homeworkList)
        : base(name, topic, difficulty)
    {
        this.homeworkList = homeworkList;
    }

    // GetHomeworkList method
    public string GetHomeworkList()
    {
        return homeworkList;
    }
}
