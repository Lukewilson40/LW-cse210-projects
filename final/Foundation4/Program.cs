using System;
using System.Collections.Generic;

// Base Activity class
class Activity
{
    private DateTime date;
    protected int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({durationMinutes} min) - {GetDetails()}";
    }

    protected virtual string GetDetails()
    {
        return $"Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Derived class for Running
class Running : Activity
{
    private double distance;

    public Running(DateTime date, int durationMinutes, double distance)
        : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (durationMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationMinutes / distance;
    }
}

// Derived class for Stationary Bicycles
class StationaryBicycle : Activity
{
    private double speed;

    public StationaryBicycle(DateTime date, int durationMinutes, double speed)
        : base(date, durationMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }
}

// Derived class for Swimming
class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0; // Convert laps to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (durationMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationMinutes / GetDistance();
    }

    protected override string GetDetails()
    {
        return $"Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}

class Program
{
    static void Main()
    {
        // Create activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new StationaryBicycle(new DateTime(2022, 11, 3), 30, 20),
            new Swimming(new DateTime(2022, 11, 3), 30, 20),
        };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
