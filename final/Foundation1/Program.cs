using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }
}

class Program
{
    static void Main()
    {
        // Create 3-4 videos
        List<Video> videos = new List<Video>
        {
            new Video
            {
                Title = "Introduction to C# Programming",
                Author = "CodeMaster",
                LengthInSeconds = 600,
                Comments = new List<Comment>
                {
                    new Comment { CommenterName = "User1", CommentText = "Great tutorial!" },
                    new Comment { CommenterName = "User2", CommentText = "Very helpful!" },
                    new Comment { CommenterName = "User3", CommentText = "I learned a lot." }
                }
            },
            // Create more videos with comments
        };

        // Iterate through the list of videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            // Display all comments for the video
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine(); // Add a newline for better readability
        }
    }
}
