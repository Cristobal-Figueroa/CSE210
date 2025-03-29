using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Make Perfect Pasta", "ChefMaster", 485);
        video1.AddComment(new Comment("PastaLover22", "This recipe changed my life! My family loved it."));
        video1.AddComment(new Comment("CookingNewbie", "Is it possible to use whole wheat pasta instead?"));
        video1.AddComment(new Comment("FoodCritic", "Great technique, but I would add more salt to the water."));
        video1.AddComment(new Comment("ItalianGrandma", "Just like I make it! Bravo!"));
        videos.Add(video1);

        Video video2 = new Video("Python Programming for Beginners", "CodeMaster", 1250);
        video2.AddComment(new Comment("NewProgrammer", "This tutorial was so easy to follow. Thank you!"));
        video2.AddComment(new Comment("PythonExpert", "Good introduction, but I would also cover list comprehensions."));
        video2.AddComment(new Comment("CS_Student", "This helped me pass my exam. Great explanation!"));
        videos.Add(video2);

        Video video3 = new Video("DIY Home Renovation Tips", "HomeBuilder", 732);
        video3.AddComment(new Comment("FirstTimeHomeowner", "I used these tips to renovate my bathroom. Saved so much money!"));
        video3.AddComment(new Comment("ContractorPro", "Good advice, but always check local building codes before starting."));
        video3.AddComment(new Comment("DesignEnthusiast", "Love the modern design ideas. What paint brand do you recommend?"));
        video3.AddComment(new Comment("DIYNewbie", "Is this suitable for beginners with no experience?"));
        videos.Add(video3);

        Video video4 = new Video("Morning Yoga Routine", "ZenYogi", 895);
        video4.AddComment(new Comment("YogaEnthusiast", "I do this routine every morning now. Feel so much better!"));
        video4.AddComment(new Comment("Beginner123", "Are there modifications for people with knee problems?"));
        video4.AddComment(new Comment("FitnessTrainer", "Great sequence! I recommend this to all my clients."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            
            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
