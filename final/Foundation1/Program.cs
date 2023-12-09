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

        List<Video> videos = new List<Video>
        {
            new Video
            {
                Title = "Introduction to C# Programming",
                Author = "CodeMaster",
                LengthInSeconds = 600,
                Comments =
                {
                    new Comment { CommenterName = "User1", CommentText = "Great tutorial!" },
                    new Comment { CommenterName = "User2", CommentText = "Very helpful!" },
                    new Comment { CommenterName = "User3", CommentText = "I learned a lot." }
                }
            },

            new Video
            {
                Title = "C# Programming Basics",
                Author = "CodeMaster",
                LengthInSeconds = 915,
                Comments =
                {
                    new Comment { CommenterName = "User1", CommentText = "Info was great!" },
                    new Comment { CommenterName = "User2", CommentText = "Very helpful again!" },
                    new Comment { CommenterName = "User3", CommentText = "I liked what I learned" }
                }
            },

            new Video
            {
                Title = "Introduction to C# Methods & Classes",
                Author = "CodeMaster",
                LengthInSeconds = 830,
                Comments =
                {
                    new Comment { CommenterName = "User1", CommentText = "I liked this!" },
                    new Comment { CommenterName = "User2", CommentText = "Very intersting!" },
                    new Comment { CommenterName = "User3", CommentText = "I was intersted in this" }
                }
            },

        };

        // Go through the list of videos and display information
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

            Console.WriteLine();
        }
    }
}