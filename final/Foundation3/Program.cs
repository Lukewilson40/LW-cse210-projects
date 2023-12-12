using System;
using System.Reflection;

// Address class to represent the address of an event
class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

// Base Event class
class Event
{
    protected string title;
    protected string description;
    protected DateTime date;
    protected TimeSpan time;
    protected Address address;


    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }


    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Generic Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

// Derived class for Lectures
class Lecture : Event
{
    private string speaker;
    private int capacity;



    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }


    public override string GetShortDescription()
    {
        return $"Type: Lecture\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

// Derived class for Receptions
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

// Derived class for Outdoor Gatherings
class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {weatherStatement}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Cityville", "CA", "12345");
        Address address2 = new Address("456 Oak St", "Townsville", "NY", "67890");
        Address address3 = new Address("789 Pine St", "Villagetown", "TX", "54321");

        // Create events
        Event genericEvent = new Event("Generic Event", "This is a generic event.", DateTime.Now, new TimeSpan(14, 0, 0), address1);
        Lecture lectureEvent = new Lecture("Programming Lecture", "Learn about programming.", DateTime.Now, new TimeSpan(15, 30, 0), address2, "John Doe", 50);
        Reception receptionEvent = new Reception("Networking Reception", "A networking event.", DateTime.Now, new TimeSpan(18, 0, 0), address3, "rsvp@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Picnic in the Park", "Enjoy a day outdoors.", DateTime.Now, new TimeSpan(12, 0, 0), address1, "Sunny with a slight breeze");

        // Display marketing messages for each event
        DisplayEventMarketing(genericEvent);
        DisplayEventMarketing(lectureEvent);
        DisplayEventMarketing(receptionEvent);
        DisplayEventMarketing(outdoorEvent);
    }

    static void DisplayEventMarketing(Event ev)
    {
        Console.WriteLine("------ Marketing Messages ------");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(ev.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(ev.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(ev.GetShortDescription());

        Console.WriteLine(new string('-', 30)); // Separator for better readability
    }
}
